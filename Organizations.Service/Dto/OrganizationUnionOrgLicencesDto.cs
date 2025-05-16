using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
  public  class OrganizationUnionOrgLicencesDto : BaseDto
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string NickName { get; set; }
        public string Code { get; set; }
        public string RegistrationEmail { get; set; }
        public string AlternativeEmail { get; set; }
        public bool IsPromise { get; set; }

        public Guid OrganizationLicencesId { get; set; }
        public int UsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid? ApplicationId { get; set; }
        public string ApplicationNameSl { get; set; }
        public string ApplicationNameFl { get; set; }
        public Guid PackageId { get; set; }
        public string PackageNameSl { get; set; }
        public string PackageNameFl { get; set; }
        public List<OrganizationLicencesModuleDto> OrganizationLicencesModules { get; set; }       
        public string ModuleNameSl { get; set; }
        public string ModuleNameFl { get; set; }
    }
}
