using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Audit.Core;
using Audit.SqlServer;
using Audit.SqlServer.Providers;
using JsonDiffer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo
// ReSharper disable ClassNeverInstantiated.Local

namespace Common.StandardInfrastructure.Audit {
    public class AuditTransaction {
        private readonly HttpContext _context;

        public AuditTransaction() {
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            _context = httpContextAccessor.HttpContext;
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (envName != null && envName.Contains(';')) {
                envName = envName.Split(';')[1].ToString();
            }
            var filePath = "appsettings." + envName + ".json";
            if (envName.Equals("Development")) {
                filePath = "appsettings.json";
            }
            var auditConnection = Helper.DecryptString( LoadJson(filePath).Audit);
            if (auditConnection == null) return;
            auditConnection = Regex.Replace(auditConnection, @"\bServer\b", "data source");
            auditConnection = Regex.Replace(auditConnection, @"\bDatabase\b", "initial catalog");
            Configuration.DataProvider = new SqlDataProvider()
            {
                ConnectionString = auditConnection,
                Schema = "dbo",
                TableName = "Audits",
                IdColumnName = "Id",
                CustomColumns = GetCustomColumns()
            };
        }
        private List<CustomColumn> GetCustomColumns()
        {
            return new List<CustomColumn>()
            {
                new CustomColumn("UserNameDomain", ev => ev.Environment.UserName),
                new CustomColumn("EventType", ev => ev.EventType),
                new CustomColumn("StartDate", ev => ev.StartDate.ToLocalTime()),
                //new CustomColumn("EndDate", ev => ev.EndDate),
                new CustomColumn("MachineName", ev => ev.Environment.MachineName),
                //new CustomColumn("CallingMethodName", ev => ev.Environment.CallingMethodName),
                //new CustomColumn("DomainName", ev => ev.Environment.DomainName),
                new CustomColumn("OldTarget", ev => TargetString(ev.Target.Old,ev.Target.New, (int)CustomString(ev).ActionID, ev.EventType)),
                new CustomColumn("NewTarget", ev => TargetString(ev.Target.New,ev.Target.Old, (int)CustomString(ev).ActionID, ev.EventType)),
                new CustomColumn("ChangedBy", ev => CustomString(ev).UserName),
                new CustomColumn("UserId", ev => CustomString(ev).UserId),
                new CustomColumn("OrganizationId", ev => CustomString(ev).OrganizationId),
                //new CustomColumn("Comment", ev => CustomString(ev).Comment),
                new CustomColumn("ActionID", ev => (int)CustomString(ev).ActionID),
                new CustomColumn("FieldIds", ev => TargetFieldId(ev.Target.New,ev.Target.Old, (int)CustomString(ev).ActionID)),
                new CustomColumn("EmployeeIds", ev => TargetEmployee(ev.Target.New,ev.Target.Old, (int)CustomString(ev).ActionID, ev.EventType))
            };
        }
        public Guid UserId => _context != null ? Guid.Parse(_context.User.FindFirst(t => t.Type == "UserId")?.Value ?? Guid.Empty.ToString()) : Guid.Empty;
        public string UserName => _context != null ? _context.User.FindFirst(t => t.Type == "UserName")?.Value : "";
        //Audit Classification
        private string TargetString(object value, object valueOld, int actionID, string entityName)
        {
            var result = "";
            var exclude = new string[] { "Id", "ModifiedDate", "OrganizationId", "ModifiedBy", "CreatedDate", "CreatedBy", "IsDelete", "Employee", "Parent", "Childerns", "AdmPath" };
            if (actionID == (int)Audit_ActionEnum.Update)
            {
                value = JsonConvert.SerializeObject(value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                valueOld = JsonConvert.SerializeObject(valueOld, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                var j1 = JToken.Parse(value.ToString());
                var j2 = JToken.Parse(valueOld.ToString());
                j1 = RemoveFields(j1, exclude, entityName);
                j2 = RemoveFields(j2, exclude, entityName);
                var diff = JsonDifferentiator.Differentiate(j1, j2);
                value = JsonConvert.SerializeObject(diff, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            }
            else
            {
                if (value != null)
                {
                    value = JsonConvert.SerializeObject(value, Formatting.None,
                               new JsonSerializerSettings()
                               {
                                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                               });
                    var valueParse = JToken.Parse(value.ToString());
                    value = RemoveFields(valueParse, exclude, entityName);
                }
                value = JsonConvert.SerializeObject(value, Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                       });
            }

            if (value != null && value.ToString() != "null")
            {
                result = value.ToString();
            }
            return result;
        }
        private string TargetEmployee(object value, object valueOld, int actionID, string entityName)
        {
            value = JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            valueOld = JsonConvert.SerializeObject(valueOld, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            var j1 = JToken.Parse(value.ToString());
            var j2 = JToken.Parse(valueOld.ToString());
            var Ids1 = CheckEmployee(j1, actionID, entityName);
            var Ids2 = CheckEmployee(j2, actionID, entityName);
            var result1 = Ids1.Union(Ids2).ToList();
            var result = string.Join(",", result1);
            return result;
        }
        private List<string> CheckEmployee(JToken token, int actionID, string entityName)
        {
            string fields = "";
            if (entityName == "Employee")
            {
                fields = "Id";
            }
            else
            {
                fields = "EmployeeId";
            }
            var employeeIds = new List<string>();
            JContainer container = token as JContainer;
            if (container == null) return employeeIds;
            if (actionID == (int)Audit_ActionEnum.AddRange || actionID == (int)Audit_ActionEnum.DeleteRange)
            {
                foreach (JToken item in container.Children())
                {
                    foreach (JToken el in item.Children())
                    {
                        JProperty p = el as JProperty;
                        if ((p != null && fields == p.Name))
                        {
                            employeeIds.Add(p.Value.ToString());
                        }
                    }
                }
            }
            else
            {
                foreach (JToken el in container.Children())
                {
                    JProperty p = el as JProperty;
                    if ((p != null && fields == p.Name))
                    {
                        employeeIds.Add(p.Value.ToString());
                    }
                }
            }
            return employeeIds;
        }
        private JToken RemoveFields(JToken token, string[] fields, string entityName)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;
            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if (
                       (p != null && fields.Contains(p.Name))
                    || (p != null && p.Value.ToString() == String.Empty)
                    || (
                             p != null
                             && p.Name.Contains(entityName)
                             && !p.Name.Contains(entityName + "F")
                             && !p.Name.Contains(entityName + "S")
                             && !p.Name.Contains("NameF")
                             && !p.Name.Contains("NameS")
                             && !p.Name.Contains("TypeF")
                             && !p.Name.Contains("TypeS")
                             && !p.Name.Contains("Number")
                             && !p.Name.Contains("Id")
                             && !p.Name.Contains("ValidStatus")


                        )
                     || (p != null && p.Value.HasValues && p.Value.GetType().IsClass && p.Value.GetType() != typeof(string))
                     )
                {

                    removeList.Add(el);

                }
                RemoveFields(el, fields, entityName);

            }
            foreach (JToken el in removeList)
            {
                el.Remove();
            }
            return token;
        }
        private AuditCustomEvent CustomString(object auditEvent)
        {
            auditEvent = JsonConvert.SerializeObject(auditEvent, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            AuditCustomEvent deserializedEvent = JsonConvert.DeserializeObject<AuditCustomEvent>(auditEvent.ToString());
            return deserializedEvent;
        }
        private ConnectionSt LoadJson(string filepath)
        {
            using var r = new StreamReader(filepath);
            var json = r.ReadToEnd();
            var items = JsonConvert.DeserializeObject<AppSetting>(json);
            return items.ConnectionStrings;
        }
        private string TargetFieldId(object value, object valueOld, int actionId)
        {
            value = JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            valueOld = JsonConvert.SerializeObject(valueOld, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            var j1 = JToken.Parse(value.ToString());
            var j2 = JToken.Parse(valueOld.ToString());
            var Ids1 = CheckFieldId(j1, actionId);
            var Ids2 = CheckFieldId(j2, actionId);
            var result1 = Ids1.Union(Ids2).ToList();
            var result = string.Join(",", result1);
            return result;
        }
        private IEnumerable<string> CheckFieldId(JToken token, int actionId)
        {
            const string fields = "Id";
            var employeeIds = new List<string>();
            if (!(token is JContainer container)) return employeeIds;
            if (actionId == (int)Audit_ActionEnum.AddRange || actionId == (int)Audit_ActionEnum.DeleteRange)
            {
                employeeIds.AddRange(from item in container.Children() from el in item.Children() select el as JProperty into p where (p != null && fields == p.Name) select p.Value.ToString());
            }
            else
            {
                employeeIds.AddRange(from el in container.Children() select el as JProperty into p where (p != null && fields == p.Name) select p.Value.ToString());
            }
            return employeeIds;
        }
        private class AppSetting
        {
            public ConnectionSt ConnectionStrings;
        }
        private class ConnectionSt
        {
            public string TAMS;
            public string Audit;
        }
    }

}
