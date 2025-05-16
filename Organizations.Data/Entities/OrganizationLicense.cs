using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
    public class OrganizationLicense : BaseModel
    {
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public Guid? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public virtual List<OrganizationLicencesModule> OrganizationLicencesModules { get; set; }
        //public Guid? OrganizationServerId { get; set; }
        //public virtual OrganizationServer OrganizationServer { get; set; }
        public Guid PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int UsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Encryption { get; set; }
        public int? NumberOfUsersHaveFaceModule { get; set; }
    }
}
