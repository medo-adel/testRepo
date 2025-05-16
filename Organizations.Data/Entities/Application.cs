using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizations.Data.Entities
{
    public class Application :BaseModel
    {
      
        public string ApplicationNameSl { get; set; }
        public string ApplicationNameFl { get; set; }
        public virtual ICollection<OrganizationLicense> OrganizationLicenseS { get; set; }
    }
}
