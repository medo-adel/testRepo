using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
  public  class ActiveDirectoryPrimaryKey :BaseModel
    {
        public string PrimaryKeyNameFl { get; set; }
        public string PrimaryKeyNameSl { get; set; }
        public List<OrganizationSetting> OrganizationSettings { get; set; }


    }
}
