using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Organizations.Service.Dto;

namespace Organizations.Service.Interfaces
{
    public interface IOrganizationLicenseService
    {
        Task<OrganizationLicenseDto> Get(Guid id);
        Task<IEnumerable<OrganizationLicenseDto>> GetAll();
        Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequest();
        Task<IEnumerable<OrganizationUnionOrgLicencesDto>> GetAllMergeOrganizationWithLicences();
        Task<IEnumerable<ActiveDirectoryPrimaryKeyDto>> GetAllPrimaryKey();
        Task<IEnumerable<ActiveDirectoryKeyDto>> GetAllADKey();
        Task<OrganizationLicenseScreenDto> GetOrganizatiolicenseScreen(Guid id);
        Task<OrganizationLicenseScreenDto> GetOrganizatiolicenseScreenForAum(Guid id);
        Task<string> UpdateSettingOrganization(OrganizationSettingDto organizationSettingDto);
        Task<OrganizationSettingDto> GetOrganizationSetting(Guid id);
        Task<IEnumerable<OrganizationLicenseDto>> OrganizationLicenceExpireWithenMonth();
        Task<OrganizationLicenseDto> GetOrganizationLicenseByOrganizationId(Guid organizationId);
        Task<bool> CheckExpireDate(Guid organizationId, Guid applicationId);
        Task<string> Add(OrganizationLicenseDto organizationLicenseDto);
        Task<string> Update(OrganizationLicenseDto organizationLicenseDto);
        Task Delete(Guid id);
        Task DeleteOrganizationLicenseRequest(Guid id);
        Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequestApproved();
        Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequestRejected();
        Task<OrganizationLicenseDto> GetById(Guid id);
        Task<OrganizationLicenseDto> GetByIdOrganizationLicenseRequest(Guid id);
        Task<List<Guid>> Getsecreenlicences(EncryptedLicencesFilter encryptedLicencesFilter);
        Task<EncryptedLicences> VerifyEncryptionWithApplication(EncryptedLicencesFilter encryptedLicencesFilter);
        Task<List<Guid?>> GetAllWorkflowModuleIds();
        Task<MobileModuleDto> GetMobileModulesForOrganization();
        Task<IEnumerable<HostApiDataDto>> GetDropdownHostApiData(Guid organizationId);
        Task<List<OrganizationSettingDto>> GetOrganizationSettingList();
        Task<Guid?> GetOrganizationLogTypeMobileId();
        Task<bool> CheckMailingNdhrModule(Guid orgId);
        Task<bool> CheckSignInModule(Guid orgId);
        Task<bool> CheckFaceModule(Guid orgId);
        Task<int?> NumberOfUserHaveFace(Guid orgId);
        Task<bool> CheckExpireDateWithSuperAdmin(string code, Guid applicationId);
        Task<string> ApproveOrganizationLicenseRequest(OrganizationLicenseDto organizationLicenseDto);
        Task<OrganizationLicenseDto> GetOrganizationDataById(Guid orgId);
        Task<OrganizationLicenseDto> GetOrganizationDataByIdAndApplicationId(EncryptedLicencesFilter encryptedLicencesFilter);
    }
}