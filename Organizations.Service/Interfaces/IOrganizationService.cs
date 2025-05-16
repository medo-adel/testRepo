using Common.StandardInfrastructure;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Organizations.Data.Entities;
using Organizations.Service.Dto;
using Organizations.Service.FilterDto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Organizations.Service.Interfaces
{
    public interface IOrganizationService
    {
        Task<string> Add(OrganizationDto organizationDto);
        Task Delete(Guid id);
        Task DeleteOrganizationRequest(Guid id);
        Task<bool> OrganizationCount();
        Task<IEnumerable<PackageDto>> GetDropdownListPackage();
        Task<IEnumerable<DropdownDto>> GetDropdownListOrganization();
        Task<IEnumerable<DropdownDto>> GetDropdownListApplication();
        Task<IEnumerable<PackageModuleDto>> GetDropdownListModule();
        Task<OrganizationDto> Get(Guid id);
        Task<OrganizationDto> GetOrganizationRequest(Guid id);
        Task<IEnumerable<OrganizationDto>> GetAll();
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequest();
        Task<PagedListDto<OrganizationDto>> GetAllOrganizationsPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto);
        Task<PagedListDto<OrganizationDto>> GetAllOrganizationCrossCloudPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto);
        Task<PagedListDto<OrganizationDto>> GetAllOrganizationCrossCloudForAumPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto);
        Task<string> Update(OrganizationDto organizationDto);
        Task<string> ApproveOrganizationRequest(OrganizationDto organizationDto);
        Task<OrganizationDto> GetCode(string code);
        Task<OrganizationWithHostsDto> GetOrganizationWithHostsByCode(string code);
        Task<OrganizationDto> GetByOrganizationId();
        Task<Stream> GenerateJsonFile(string code);
        Stream DownLoadOrganizationServer(string code, bool hash);
        Task<(Organization, string)> UpdateOrganizationFromJsonFile(IFormFile file);
        Task<(Organization, string)> UpdateOrganizationFromJsonFileLicence(JObject organizationobject);
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequestApproved();
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequestRejeted();

        Stream UploadServerLicenseFromJsonFile(IFormFile file, string organizationCode);
        Stream UpdateAdminPasswordFile(string newPassword);
        Task<OrganizationCodeDto> GetOrganizationCode(Guid organizationId);
        Task<bool> VerifyEncryption(Guid id);
        Task<IEnumerable<TimeZonesDto>> GetTimeZones();
        Task<List<SettingActualWorkingDto>> GetSettingActualWorking(Guid organizationId);
        Task<IEnumerable<DropdownDto>> GetAllOrganizaionRequestCloud();
        Task<string> AddSettingActualWorking(List<SettingActualWorkingDto> settingActualWorkingDto);
        Task<IEnumerable<PackageModuleCheckedDto>> GetDropdownListModuleChecked(Guid packageId);
        Task<Organization> CheckCode(string code);
        Task<bool> GetOrganizationIsShowWordAndExcel(Guid? organizaionId);
        Task<bool> GetOrganizationIsShowActualWorkingDay(Guid? organizaionId);
        Task<bool> GetOrganizationIsAllowPasswordConstraints(Guid? organizaionId);
        Task<bool> GetOrganizationIsUseOneDeviceForUserInquiry(Guid? organizaionId);
        Task<IEnumerable<Guid>> GetOrganizationIdsList();
        Task<List<SettingActualWorkingDto>> GetSettingActualWorkingAnonymous();
        List<DropdownDto> GetLogTypeMobileForOrganization();
        Task<string> GetOrganizationTimeZone(Guid id);
        List<DropdownDto> GetAllOrganizationTypeEnum();
        Task<IEnumerable<DropdownDto>> GetAllOrganizaionCloud();
        Task<(Organization, string)> UpdateOrganizationCrossCloudFromJsonFile(JObject organizationobject);
        Task<bool> IsOrganizaionCrossCloud();
        Task<bool> IsOrganizaionCrossCloudClient();
        Task<bool> IsOrganizaionCrossCloudForAum(Guid? orgId);
        Task<bool> IsOrganizaionCrossCloudClientForAum(Guid? orgId);
        Task<(Organization, string)> UpdateOrganizationCrossCloudFromJsonFile(IFormFile file);
        Task<List<Guid>> GetAllOrganizationIds();
        Task<AddOrganizationSettingDto> GetOrganizationSetting(Guid id);
    }
}
