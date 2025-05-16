using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizations.Service.Dto;
using Organizations.Service.Interfaces;
using Organizations.Service.Services;
using Organizations.WebAPI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organizations.WebAPI.Controllers
{
    /// <inheritdoc />
    public class OrganizationLicensesController : BaseController
    {
        private readonly IOrganizationLicenseService _organizationLicenseService;

        /// <inheritdoc />
        public OrganizationLicensesController(IOrganizationLicenseService organizationLicenseService)
        {
            _organizationLicenseService = organizationLicenseService;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organization = await _organizationLicenseService.Get(id);
            return Ok(organization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizatiolicenseScreen(Guid id)
        {
            var organization = await _organizationLicenseService.GetOrganizatiolicenseScreen(id);
            return Ok(organization);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizatiolicenseScreenForAum(Guid id)
        {
            var organization = await _organizationLicenseService.GetOrganizatiolicenseScreenForAum(id);
            return Ok(organization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _organizationLicenseService.GetAll();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationLicenseRequest()
        {
            var list = await _organizationLicenseService.GetAllOrganizationLicenseRequest();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationLicenseRequestApproved()
        {
            var list = await _organizationLicenseService.GetAllOrganizationLicenseRequestApproved();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationLicenseRequestRejected()
        {
            var list = await _organizationLicenseService.GetAllOrganizationLicenseRequestRejected();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMergeOrganizationWithLicences()
        {
            var list = await _organizationLicenseService.GetAllMergeOrganizationWithLicences();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OrganizationLicenceExpireWithenMonth()
        {
            var list = await _organizationLicenseService.OrganizationLicenceExpireWithenMonth();
            return Ok(list);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrganizationSetting(Guid id)
        {
            var organization = await _organizationLicenseService.GetOrganizationSetting(id);
            return Ok(organization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPrimaryKey()
        {
            var list = await _organizationLicenseService.GetAllPrimaryKey();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllADKey()
        {
            var list = await _organizationLicenseService.GetAllADKey();
            return Ok(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationSettingDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSettingOrganization(OrganizationSettingDto organizationSettingDto)
        {
            var message = await _organizationLicenseService.UpdateSettingOrganization(organizationSettingDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationLicenseDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(OrganizationLicenseDto organizationLicenseDto)
        {
            var message = await _organizationLicenseService.Add(organizationLicenseDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> ApproveOrganizationLicenseRequest(OrganizationLicenseDto organizationLicenseDto)
        {
            var message = await _organizationLicenseService.ApproveOrganizationLicenseRequest(organizationLicenseDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationLicenseDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(OrganizationLicenseDto organizationLicenseDto)
        {
            var message = await _organizationLicenseService.Update(organizationLicenseDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationLicenseByOrganizationId(Guid organizationId)
        {
            var organizationLicense = await _organizationLicenseService.GetOrganizationLicenseByOrganizationId(organizationId);
            return Ok(organizationLicense);
        }
        
        [HttpGet("{organizationId}/{applicationId}")]
        public async Task<IActionResult> CheckExpireDate(Guid organizationId, Guid applicationId)
        {
            var organizationLicense = await _organizationLicenseService.CheckExpireDate(organizationId,applicationId);
            return Ok(organizationLicense);

        }
        [HttpGet("{code}/{applicationId}")]
        public async Task<IActionResult> CheckExpireDateWithSuperAdmin(string code, Guid applicationId)
        {
            var organizationLicense = await _organizationLicenseService.CheckExpireDateWithSuperAdmin(code, applicationId);
            return Ok(organizationLicense);

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _organizationLicenseService.Delete(id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationLicenseRequest(Guid id)
        {
            await _organizationLicenseService.DeleteOrganizationLicenseRequest(id);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var organization = await _organizationLicenseService.GetById(id);
            return Ok(organization);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrganizationLicenseRequest(Guid id)
        {
            var organization = await _organizationLicenseService.GetByIdOrganizationLicenseRequest(id);
            return Ok(organization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedLicencesFilter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Getsecreenlicences(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            return Ok(await _organizationLicenseService.Getsecreenlicences(encryptedLicencesFilter));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedLicencesFilter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> VerifyEncryptionWithApplication(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            return Ok(await _organizationLicenseService.VerifyEncryptionWithApplication(encryptedLicencesFilter));
        }
        /// <summary>
        /// Get Workflow Module Ids for current organization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWorkflowModuleIds()
        {
            var list = await _organizationLicenseService.GetAllWorkflowModuleIds();
            return Ok(list);
        }
        /// <summary>
        /// Get Mobile Modules For Mobile App Screens
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMobileModulesForOrganization()
        {
            var list = await _organizationLicenseService.GetMobileModulesForOrganization();
            return Ok(list);
        }

        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetDropdownHostApiData(Guid organizationId)
        {
            var organization = await _organizationLicenseService.GetDropdownHostApiData(organizationId);
            return Ok(organization);
        }        
        [HttpGet]
        public async Task<IActionResult> GetOrganizationSettingList()
        {
            var list = await _organizationLicenseService.GetOrganizationSettingList();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrganizationLogTypeMobileId()
        {
            var list = await _organizationLicenseService.GetOrganizationLogTypeMobileId();
            return Ok(list);
        }

        [HttpGet("{organizationId}")]
        public async Task<IActionResult> CheckMailingNdhrModule(Guid organizationId)
        {
            var data = await _organizationLicenseService.CheckMailingNdhrModule(organizationId);
            return Ok(data);
        }

        [HttpGet("{organizationId}")]
        public async Task<IActionResult> CheckSignInModule(Guid organizationId)
        {
            var data = await _organizationLicenseService.CheckSignInModule(organizationId);
            return Ok(data);
        }
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> CheckFaceModule(Guid organizationId)
        {
            var data = await _organizationLicenseService.CheckFaceModule(organizationId);
            return Ok(data);
        }
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> NumberOfUserHaveFace(Guid organizationId)
        {
            var data = await _organizationLicenseService.NumberOfUserHaveFace(organizationId);
            return Ok(data);
        }
        [HttpGet("{orgId}")]
        public async Task<IActionResult> GetOrganizationDataById(Guid orgId)
        {
            var organization = await _organizationLicenseService.GetOrganizationDataById(orgId);
            return Ok(organization);
        }
        [HttpPost]
        public async Task<IActionResult> GetOrganizationDataByIdAndApplicationId(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            return Ok(await _organizationLicenseService.GetOrganizationDataByIdAndApplicationId(encryptedLicencesFilter));
        }
    }
}