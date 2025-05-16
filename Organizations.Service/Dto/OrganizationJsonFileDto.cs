using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
    public partial class OrganizationJsonFileDto
    {
        public Guid Id { get; set; }
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string NickName { get; set; }
        public string Code { get; set; }
        public string RegistrationEmail { get; set; }
        public string AlternativeEmail { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }
        public string LogoURLFl { get; set; }
        public string LogoURLSl { get; set; }
        public string AdminPassword { get; set; }
        public bool IsPromise { get; set; }
        public string Encryption { get; set; }
        public Guid? OrganizationTypeId { get; set; }
        public Guid? OrganizationId { get; set; }
        public List<OrganizationLicenseOriginalDto> OrganizationLicenses { get; set; }
    }

    
}
