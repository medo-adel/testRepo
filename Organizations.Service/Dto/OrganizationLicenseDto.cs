using Microsoft.AspNetCore.Http;
using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
  public  class OrganizationLicenseDto :BaseDto
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrganizationLicenseDto()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public Guid OrganizationId { get; set; }
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string Code { get; set; }
        public Guid PackageId { get; set; }
        public string PackageNameSl { get; set; }
        public string PackageNameFl { get; set; }
        public Guid? ApplicationId { get; set; }
        public string ApplicationNameSl { get; set; }
        public string ApplicationNameFl { get; set; }
        public int UsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public string ExpireDateStr => ExpireDate.ToString(_httpContextAccessor.HttpContext.Request.Headers["lang"] == "ar-EG" ? "yyyy/MM/dd" : "dd/MM/yyyy");
        public int? NumberOfUsersHaveFaceModule { get; set; }

        public DateTime ExpireDate { get; set; }

        public string Encryption { get; set; }
        public bool? IsApprove { get; set; }
        public List<OrganizationLicencesModuleDto> OrganizationLicencesModules { get; set; }

        public List<OrganizationHostApisDto> OrganizationHostApis { get; set; }

    }
    public class OrganizationHostApisDto
    {
        public Guid? Id { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? HostApiDataId { get; set; }
        public string Value { get; set; }

    }

    public class EncryptedLicences
    {
        public bool? EncruptedTrue { get; set; } = true;

        public OrganizationLicenseDto OrganizationLicense { get; set; }
    }
    public class EncryptedLicencesFilter
    {
        public Guid OrganizationId { get; set; }
        public Guid ApplicationId { get; set; }
    }
    public class AdminUserData
    {
        public string AdminPassword { get; set; }
        public Guid? OrganizationId { get; set; }
    }
    public class OrganizationLicenseScreenDto
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrganizationLicenseScreenDto()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public int UsersCount { get; set; }
        public int? InquiryUsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public string ExpireDateStr => ExpireDate.ToString(_httpContextAccessor.HttpContext.Request.Headers["lang"] == "ar-EG" ? "yyyy/MM/dd" : "dd/MM/yyyy");
        public DateTime ExpireDate { get; set; }
        public DateTime? InquiryExpireDate { get; set; }
        public string InquiryExpireDateStr => InquiryExpireDate?.ToString(_httpContextAccessor.HttpContext.Request.Headers["lang"] == "ar-EG" ? "yyyy/MM/dd" : "dd/MM/yyyy");

    }
}
