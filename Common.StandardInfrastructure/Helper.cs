using Common.StandardInfrastructure.Interface;
using LinqKit;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Common.StandardInfrastructure
{
    public static class Helper
    {
        public static string encryptKey = "securityIsFirstin2024For100of100";

        public static bool ValidateDuringDate(DateTime startDateFromDataBase, DateTime? endDateFromDataBase, DateTime startDate, DateTime endDate)
        {
            if (endDateFromDataBase != null)
            {
                return (startDate.Date >= startDateFromDataBase.Date && startDate.Date <= endDateFromDataBase.Value.Date)
                    && (endDate.Date >= startDateFromDataBase.Date && endDate.Date <= endDateFromDataBase.Value.Date)
                     && (startDate.Date <= endDate.Date);
            }
            else
            {
                return (startDate.Date >= startDateFromDataBase.Date)
                && (endDate.Date >= startDateFromDataBase.Date)
                 && (startDate.Date <= endDate.Date);
            }
        }
        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static bool ValidateHiringPeriod(DateTime startDate, DateTime startDateFromDataBase, DateTime? endDateFromDataBase) => startDateFromDataBase.Date <= startDate.Date && (endDateFromDataBase == null || endDateFromDataBase.Value.Date > startDate.Date);

        public static Expression<Func<T, bool>> GetPredicate<T, TDto>(TDto dto, bool? withDateFilter = true)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var predicate = PredicateBuilder.New<T>(true);
            var properties = typeof(TDto).GetProperties().Select(x => new { type = x.PropertyType, property = x.Name, value = x.GetValue(dto) }).Where(x => x.value != null).ToList();
            foreach (var filter in properties)
            {
                if (!PropertyExists(filter.property, typeof(T)) || filter.type == typeof(Guid?[])) continue;
                var member = Expression.Property(param, filter.property);
                var constant = GetValueExpression(filter.property, filter.value, param);
                var valType = filter?.value.GetType().GetProperty("Name");

                var value = valType != null ? filter?.value.GetType().GetProperty("Name")?.GetValue(filter.value, null) : filter.value;
                var isContain = Convert.ToInt16(filter?.value.GetType().GetProperty("IsContain")?.GetValue(filter.value, null));
                if (value.GetType().Name == "String" && string.IsNullOrWhiteSpace(value.ToString())) continue;


                if (filter.type == typeof(DateTime?))
                {
                    if (withDateFilter == true)
                    {
                        Expression left = Expression.Property(param, filter.property);
                        var dayDate = ((DateTime?)filter.value).Value.Date;
                        Expression right1 = Expression.Constant(dayDate);                    
                        if (properties.Count(q => q.type == typeof(DateTime?)) == 2)
                        {
                            var condition1 = filter.property.ToLower().Contains("enddate") ? Expression.LessThanOrEqual(left, right1) : Expression.GreaterThanOrEqual(left, right1);
                            predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                        }                     
                        else
                        {
                            var condition1 = Expression.GreaterThanOrEqual(left, right1);
                            predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                            //predicate.And(Expression.Lambda<Func<T, bool>>(condition1, param));
                            //var dayAfter = ((DateTime?)DateTime.MaxValue);
                            //Expression right2 = Expression.Constant(dayAfter);
                            //var condition2 = Expression.LessThan(left, right2);
                            //predicate.And(Expression.Lambda<Func<T, bool>>(condition2, param));
                        }
                    }
                    else
                    {

                    }
                    continue;
                }
                if (value.GetType().Name == "String")
                {
                    if (isContain == (int)Filter_GridEnum.Contains)
                    {
                        predicate.And(Expression.Lambda<Func<T, bool>>(member.Contain(constant), param));

                    }
                    else if (isContain == (int)Filter_GridEnum.StartWith)
                    {
                        predicate.And(Expression.Lambda<Func<T, bool>>(member.StartWith(constant), param));
                    }
                    else if (isContain == (int)Filter_GridEnum.EndWith)
                    {
                        predicate.And(Expression.Lambda<Func<T, bool>>(member.EndWith(constant), param));
                    }
                    else if (isContain == (int)Filter_GridEnum.Equal)
                    {
                        predicate.And(Expression.Lambda<Func<T, bool>>(Expression.Equal(member, constant), param));
                    }
                }
                else
                {
                    predicate.And(Expression.Lambda<Func<T, bool>>(Expression.Equal(member, constant), param));
                }
            }
            return predicate;
        }
        public static Expression<Func<T, bool>> GetPredicateIsExist<T, TDto>(TDto dto, bool includeCountry = true)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var predicate = PredicateBuilder.New<T>(false);
            var properties = typeof(TDto).GetProperties().Where(f => f.GetValue(dto) != null && (f.Name == "Code" || f.Name.ToLower().EndsWith("fl") || f.Name.ToLower().EndsWith("sl") || f.Name == "PenaltieGroupCode" || f.Name.ToLower() == "id" || (f.Name.ToLower() == "countryid" && includeCountry) || (f.Name.ToLower() == "dutytypeid" && includeCountry))).Select(x => new { type = x.PropertyType, property = x.Name, value = x.GetValue(dto) }).ToList();
            foreach (var filter in properties)
            {
                var member = Expression.Property(param, filter.property);
                UnaryExpression constant = GetValueExpression(filter.property, filter.value, param);
                BinaryExpression expression = null;

                expression = filter.type == typeof(string) ?
                    Expression.Equal(member.TrimToLower(), constant.TrimToLower())
                    :
                    filter.property == "Id" ? Expression.NotEqual(member, constant) : Expression.Equal(member, constant);

                var lambda = (filter.property.ToLower().EndsWith("fl") || filter.property == "Code" || filter.property.ToLower().EndsWith("sl")) ? predicate.Or(Expression.Lambda<Func<T, bool>>(expression.AddNullCheck(member), param))
                    :
                  predicate.And(Expression.Lambda<Func<T, bool>>(expression, param));
            }
            return predicate;
        }
        private static UnaryExpression GetValueExpression(string propertyName, object val, ParameterExpression param)
        {

            var member = Expression.Property(param, propertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();
            var valType = val.GetType().GetProperty("Name");
            if (valType != null)
            {
                var value = valType.GetValue(val, null);
                var constant = Expression.Constant(value);
                return Expression.Convert(constant, propertyType);
            }
            else
            {
                var constant = Expression.Constant(val);
                return Expression.Convert(constant, propertyType);
            }
        }
        public static bool SortFromAnotherService(this Type type, string sortField) => type?.GetProperty(sortField, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)?.CustomAttributes?.Select(q => q.AttributeType.Name == "DisplayNameAttribute").Any() ?? false;
        private static bool PropertyExists(string prop, Type t)
        {

            var propInfo = t.GetMember(prop)
                .Where(p => p is PropertyInfo)
                .Cast<PropertyInfo>()
                .FirstOrDefault();

            if (propInfo != null)
            {
                t = propInfo.PropertyType;

                if (t.GetInterfaces().Contains(typeof(IEnumerable)) && t != typeof(string))
                {
                    t = t.IsGenericType ? t.GetGenericArguments()[0] : t.GetElementType();

                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public static string GetWeekDay(Guid? weekDay)
        {
            var weekDaysEnums = Enum.GetValues(typeof(WeekDaysEnum));
            foreach (var enumItem in weekDaysEnums)
            {
                if (((WeekDaysEnum)enumItem).GetEnumGuid() == weekDay) return enumItem.ToString();
            }
            return null;
        }
        public static bool IsNullOrEmptyDate(DateTime date)
        {
            return date == null || date == default(DateTime);
        }
        public static bool ValidateTimeDuring(TimeSpan firstStartTime, TimeSpan firstEndTime, TimeSpan secondStartTime, TimeSpan secondEndTime)
        {
            //var isValid = (firstStartTime < firstEndTime && secondStartTime < secondEndTime) &&  // start time must be less than the end time 
            //        (secondStartTime >= firstEndTime); // to prevent the intersection between the two times
            //return isValid;

            // If the time spans do not wrap around midnight
            bool firstSpanIsValid = firstStartTime < firstEndTime;
            bool secondSpanIsValid = secondStartTime < secondEndTime;

            if (firstSpanIsValid && secondSpanIsValid)
            {
                // Normal case where both spans do not wrap around midnight
                return !(secondStartTime < firstEndTime && firstStartTime < secondEndTime);
            }
            else if (!firstSpanIsValid && secondSpanIsValid)
            {
                // First span wraps around midnight
                return !(secondStartTime < firstEndTime || firstStartTime < secondEndTime);
            }
            else if (firstSpanIsValid && !secondSpanIsValid)
            {
                // Second span wraps around midnight
                return !(secondStartTime < firstEndTime || firstStartTime < secondEndTime);
            }
            else
            {
                // Both spans wrap around midnight
                return false; 
            }
        }
        public static byte[] ToByteArray<T>(IEnumerable<T> obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static IEnumerable<T> FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(IEnumerable<T>);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (IEnumerable<T>)obj;
            }
        }
        public static Expression<Func<T, bool>> GetDatePredicate<T>(DateTime startDate, DateTime endDate) where T : IDateModel
        {
            return PredicateBuilder.New<T>(q => q.StartDate.Date <= endDate.Date && startDate.Date <= q.EndDate.Date);

        }
        public static Expression<Func<T, bool>> GetTimeEntryPredicate<T>(DateTime startDate, DateTime endDate) where T : ITimeEntryModel
        {
            return PredicateBuilder.New<T>(q => q.TimeEntry.Date <= endDate.Date && startDate.Date <= q.TimeEntry.Date);
        }
        public static Expression<Func<T, bool>> GetStartDatePredicate<T>(DateTime startDate, DateTime endDate) where T : IStartDateModel
        {
            return PredicateBuilder.New<T>(q => q.StartDate <= endDate && startDate <= q.StartDate);
        }
        public static Expression<Func<T, bool>> GetDayOfWorkPredicate<T>(DateTime startDate, DateTime endDate) where T : IDayOfWorkModel
        {
            return PredicateBuilder.New<T>(q => q.DayOfWork.Date <= endDate.Date && startDate.Date <= q.DayOfWork.Date);
        }
        public static int ChangeProperty()
        {
            ISessionStorage session = new SessionStorage();
            if (session?.PrimaryLanguage == null) return (int)ChangePropertyEnum.EnAr;
            if (string.IsNullOrWhiteSpace(session?.SecondaryLanguage))
            {
                return session?.PrimaryLanguage == "ar" ? (int)ChangePropertyEnum.Ar : (int)ChangePropertyEnum.En;
            }
            return session?.PrimaryLanguage == "ar" ? (int)ChangePropertyEnum.ArEn : (int)ChangePropertyEnum.EnAr;
        }
        public enum ChangePropertyEnum
        {
            ArEn = 1,
            EnAr = 2,
            Ar = 3,
            En = 4
        }
        public static IEnumerable<string> GetMacAddress(string code) => NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback).Select(nic => (code + nic.GetPhysicalAddress()).Encrypt());
        public static IEnumerable<string> GetProcessor(string code)
        {
            var managementObjectSearcherList = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (var managementObjectSearcher in managementObjectSearcherList.Get()) yield return (code + managementObjectSearcher["ProcessorId"]).Encrypt();
        }
        public static IEnumerable<string> GetMotherBoard(string code)
        {
            var managementObjectSearcherList = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (var managementObjectSearcher in managementObjectSearcherList.Get()) yield return (code + managementObjectSearcher["SerialNumber"]).Encrypt();
        }

        public static List<string> GetChangedProperties<T>(T A, T B)
        {
            var result = new List<string>();
            if (A != null && B != null)
            {
                var type = typeof(T);
                var exclude = new string[] { "ModifiedDate", "OrganizationId", "ModifiedBy", "CreatedDate", "CreatedBy", "IsDelete", "Employee", "Parent", "Childerns", "AdmPath", "Id" };
                var allProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var list = allProperties.ToList();
                list.ForEach(pi =>
                {
                    var AValue = type.GetProperty(pi.Name).GetValue(A, null);
                    var BValue = type.GetProperty(pi.Name).GetValue(B, null);
                    if (AValue != BValue && (AValue == null || !AValue.Equals(BValue)) && !exclude.Contains(pi.Name) && !pi.Name.Contains(type.Name.ToString()))
                    {
                        if (BValue != null && (!BValue.GetType().IsClass || BValue.GetType() == typeof(string)))
                        {
                            result.Add(pi.Name);

                        }
                        else if (AValue != null && (!AValue.GetType().IsClass || AValue.GetType() == typeof(string)))
                        {
                            result.Add(pi.Name);
                        }
                    }
                });
            }
            return result;
        }
        public static T EditOriginalValues<T>(T entityNew, T entityOld)
        {
            try
            {
                const string createdByString = "CreatedBy";
                const string createdDateString = "CreatedDate";
                var createdByOldValue = Guid.Empty;
                DateTime createdDateOldValue = default;
                var oldType = entityOld.GetType();
                var createdByOld = oldType.GetProperty(createdByString);
                if (createdByOld != null) createdByOldValue = Guid.Parse(createdByOld.GetValue(entityOld, null).ToString());
                var createdDateOld = oldType.GetProperty(createdDateString);
                if (createdDateOld != null)
                { 
                    DateTime daydate = (DateTime)(oldType.GetProperty(createdDateString)?.GetValue(entityOld, null));
                    createdDateOldValue = daydate;
                }
                var newType = entityNew.GetType();
                var createdBy = newType.GetProperty(createdByString);
                if (createdBy != null) createdBy.SetValue(entityNew, Convert.ChangeType(createdByOldValue, createdBy.PropertyType), null);
                var createdDate = newType.GetProperty(createdDateString);
                if (createdDate != null) createdDate.SetValue(entityNew, Convert.ChangeType(createdDateOldValue, createdDate.PropertyType), null);
            }
            catch(Exception ex)
            {
                // ignored
            }
            return entityNew;
        }
        public static string GenerateToken(Guid? organizationId = null)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryDifficultSuperSecretKey"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // how to send data like admin or roles with the token
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44364",
                audience: "http://localhost:44364",
                claims: new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "superadmin"),
                    new Claim("UserName", "superadmin"),
                    new Claim("UserId", "00000000-0000-0000-0000-000000000000"),
                    new Claim("EmployeeId", Guid.Empty.ToString()),
                    new Claim("OrganizationId", organizationId==null?"":organizationId.ToString()),
                    new Claim("PrimaryLanguage", ""),
                    new Claim("SecondaryLanguage", ""),
                    new Claim("LocationId", ""),
                    new Claim("IsSuperAdmin", "true"),
                    new Claim("IsMobile", "false"),
                    new Claim("Roles", "superadmin")
                },
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );
            return $"Bearer {new JwtSecurityTokenHandler().WriteToken(tokeOptions)}";
        }
        public static string GetArabicDay(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Sunday => "الاحد",
                DayOfWeek.Monday => "الاثنين",
                DayOfWeek.Tuesday => "الثلاثاء",
                DayOfWeek.Wednesday => "الاربعاء",
                DayOfWeek.Thursday => "الخميس",
                DayOfWeek.Friday => "الجمعه",
                DayOfWeek.Saturday => "السبت",
                _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Invalid day of week."),
            };
        }
    }

    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory,
            Func<TDisposable, TResult> map) where TDisposable : IDisposable
        {
            using var disposable = factory();
            return map(disposable);
        }
    }
}