using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
  public  class OrganizationLicencesModuleDto :BaseDto
    {
        public Guid ModuleId { get; set; }
        public Guid OrganizationLicenseId { get; set; }
        public string Encryption { get; set; }

    }
}
