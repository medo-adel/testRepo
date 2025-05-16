using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizations.Data.Entities
{
    public class Package : BaseModel
    {
       
        public string PackageNameSl { get; set; }
        public string PackageNameFl { get; set; }
        public Guid ApplicationId { get; set; }
        public virtual List<PackageModule> PackageModules { get; set; }

        public virtual ICollection<OrganizationLicense> OrganizationLicenseS { get; set; }
    }
}
