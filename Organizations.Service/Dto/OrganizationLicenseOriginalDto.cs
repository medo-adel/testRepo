using System;
using System.Collections.Generic;

namespace Organizations.Service.Dto
{
        public class OrganizationLicenseOriginalDto
        {
            public Guid Id { get; set; }
            public Guid OrganizationId { get; set; }
            public Guid? ApplicationId { get; set; }
            public List<OrganizationLicencesModuleOriginalDto> OrganizationLicencesModules { get; set; }
            public Guid PackageId { get; set; }
            public int UsersCount { get; set; }
            public int EmployeesCount { get; set; }
            public DateTime ExpireDate { get; set; }
            public string Encryption { get; set; }
           public int? NumberOfUsersHaveFaceModule { get; set; }


    }

}
