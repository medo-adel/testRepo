using System;

namespace Organizations.Service.Dto
{
        public class OrganizationLicencesModuleOriginalDto
        {
            public Guid Id { get; set; }
            public Guid ModuleId { get; set; }
            public Guid OrganizationLicenseId { get; set; }
            public string Encryption { get; set; }

        }    
}
