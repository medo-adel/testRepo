using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
   public class OrganizationLicencesModule :BaseModel
    {
        public Guid ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public Guid OrganizationLicenseId { get; set; }
        public virtual OrganizationLicense OrganizationLicense { get; set; }
        public string Encryption { get; set; }
    }
}
