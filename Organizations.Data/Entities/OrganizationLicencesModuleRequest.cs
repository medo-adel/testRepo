using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities
{
   public class OrganizationLicencesModuleRequest : BaseModel
    {
        public Guid ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public Guid OrganizationLicenseId { get; set; }
        [ForeignKey("OrganizationLicenseId")]
        public virtual OrganizationLicenseRequest OrganizationLicenseRequest { get; set; }
        public string Encryption { get; set; }
    }
}
