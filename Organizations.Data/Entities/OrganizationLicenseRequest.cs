using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities
{
    public class OrganizationLicenseRequest : BaseModel
    {
        public Guid OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public Guid? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public virtual List<OrganizationLicencesModuleRequest> OrganizationLicencesModules { get; set; }        
        public Guid PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int UsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Encryption { get; set; }
        public bool? IsApprove { get; set; }
        public int? NumberOfUsersHaveFaceModule { get; set; }

    }
}
