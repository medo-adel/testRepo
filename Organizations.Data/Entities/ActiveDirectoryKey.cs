using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
   public class ActiveDirectoryKey :BaseModel
    {
        public string ActiveDirectoryKeyNameFl { get; set; }
        public string ActiveDirectoryKeyNameSl { get; set; }
        public List<OrganizationSetting> OrganizationSettings { get; set; }


    }
}
