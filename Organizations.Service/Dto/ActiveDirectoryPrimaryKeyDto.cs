using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class ActiveDirectoryPrimaryKeyDto :BaseDto
    {
        public string PrimaryKeyNameFl { get; set; }
        public string PrimaryKeyNameSl { get; set; }
    }
}
