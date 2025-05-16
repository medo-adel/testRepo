using Microsoft.AspNetCore.Http;
using Organizations.Data.Entities;
using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Organizations.Service.Dto
{
  public  class OrganizationDto : BaseDto
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrganizationDto()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string NickName { get; set; }
        public string Code { get; set; }
        [StringLength(128)]
        public string RegistrationEmail { get; set; }
        [StringLength(128)]
        public string AlternativeEmail { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }
        public string LogoURLFl { get; set; }
        public string LogoURLSl { get; set; }
        public string AdminPassword { get; set; }
        public string PackageNameSl { get; set; }
        public string PackageNameFl { get; set; }
        public bool IsPromise { get; set; }
        public string Encryption { get; set; }

        public List<OrganizationLicenseDto> OrganizationLicenses { get; set; }
        public int UsersCount { get; set; }
        public int EmployeesCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ExpireDateStr => ExpireDate.ToString(_httpContextAccessor.HttpContext.Request.Headers["lang"] == "ar-EG" ? "yyyy/MM/dd" : "dd/MM/yyyy");

        public Guid? TimeZoneId { get; set; }
        public bool? IsReviewLogs { get; set; }
        public string LogoPath { get; set; }
        public bool? IsActiveDirectory { get; set; }
        public string AdDomainName { get; set; }
        public Guid? PrimaryKeyId { get; set; }
        public Guid? ADKeyId { get; set; }
        public string ActiveDirectoryKeyNameEn { get; set; }
        public string ActiveDirectoryKeyNameAr { get; set; }
        public bool? IsApprove { get; set; }
        //public string FileName { get; set; }
        public Guid? OrganizationTypeId { get; set; }
        public Guid? OrganizationId { get; set; }
        
    }
  
    public class AddOrganizationSettingDto : BaseDto {
        public bool? IsThirdSign { get; set; }
        public double? TimeSendNotification { get; set; }
        public double? PermisionTimeForThirdSign { get; set; }
        public Guid? LogTypeMobileId { get; set; }
        public double? countOfSecondsToCheckLiveness { get; set; }
        public double? livenessLevelOptions { get; set; }
        public bool? UseOneDeviceForUserInquiry { get; set; }
    }


    public class OrganizationWithHostsDto : OrganizationDto
    {
        public string HostApiUrl { get; set; }
        public string NotificationApiUrl { get; set; }
        public string LogsApiHubUrl { get; set; }
        public string LogoutApiHubUrl { get; set; }
    }

    public class OrganizationCodeDto
    {
        public string Code { get; set; }
        public bool IsPromise { get; set; } = false;

    }
}
