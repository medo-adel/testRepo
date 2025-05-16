using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizations.Data.Entities
{
    public class Module : BaseModel
    {
      
        public string ModuleNameSl { get; set; }
        public string ModuleNameFl { get; set; }
        public string Price { get; set; }
        public virtual List<ModuleScreen> ModuleScreens { get; set; }
        public virtual List<PackageModule> PackageModules { get; set; }
        public virtual List<OrganizationLicencesModule> OrganizationLicencesModules { get; set; }


    }
}
