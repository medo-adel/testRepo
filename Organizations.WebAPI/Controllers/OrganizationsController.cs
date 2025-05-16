using Common.StandardInfrastructure;
using Common.StandardInfrastructure.CommonDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Organizations.Service.Dto;
using Organizations.Service.FilterDto;
using Organizations.Service.Interfaces;
using Organizations.WebAPI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organizations.WebAPI.Controllers
{
    /// <inheritdoc />
    public class OrganizationsController : BaseController
    {
        private readonly IOrganizationService _organizationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;


        /// <inheritdoc />
        public OrganizationsController(IOrganizationService organizationService, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _organizationService = organizationService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filteringDto"></param>
        /// <param name="pagingSortingDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetAllPaged([FromBody] OrganizationFilterDto filteringDto, [FromQuery] PagingSortingDto pagingSortingDto)
        {
            var list = await _organizationService.GetAllOrganizationsPaged(filteringDto, pagingSortingDto);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllOrganizationCrossCloudPaged([FromBody] OrganizationFilterDto filteringDto, [FromQuery] PagingSortingDto pagingSortingDto)
        {
            var list = await _organizationService.GetAllOrganizationCrossCloudPaged(filteringDto, pagingSortingDto);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllOrganizationCrossCloudForAumPaged([FromBody] OrganizationFilterDto filteringDto, [FromQuery] PagingSortingDto pagingSortingDto)
        {
            var list = await _organizationService.GetAllOrganizationCrossCloudForAumPaged(filteringDto, pagingSortingDto);
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _organizationService.GetAll();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationRequest()
        {
            var list = await _organizationService.GetAllOrganizationRequest();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationRequestApproved()
        {
            var list = await _organizationService.GetAllOrganizationRequestApproved();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizationRequestRejeted()
        {
            var list = await _organizationService.GetAllOrganizationRequestRejeted();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTimeZones()
        {
            var list = await _organizationService.GetTimeZones();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDropdownListOrganization()
        {
            var list = await _organizationService.GetDropdownListOrganization();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDropdownListApplication()
        {
            var list = await _organizationService.GetDropdownListApplication();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDropdownListModule()
        {
            var list = await _organizationService.GetDropdownListModule();
            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDropdownListPackage()
        {
            var list = await _organizationService.GetDropdownListPackage();
            return Ok(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var organization = await _organizationService.Get(id);
            return Ok(organization);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationRequest(Guid id)
        {
            var organization = await _organizationService.GetOrganizationRequest(id);
            return Ok(organization);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(OrganizationDto organizationDto)
        {
            var message = await _organizationService.Add(organizationDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> ApproveOrganizationRequest(OrganizationDto organizationDto)
        {
            var message = await _organizationService.ApproveOrganizationRequest(organizationDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(OrganizationDto organizationDto)
        {
            var message = await _organizationService.Update(organizationDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public async Task<IActionResult> GetCode(string code)
        {
            var organization = await _organizationService.GetCode(code);
            if (organization == null)
            {
                return BadRequest("Invalid organization Code");
            }
            return Ok(organization);
        }
        [AllowAnonymous]
        [HttpGet("{code}")]
        public async Task<IActionResult> CheckCode(string code)
        {
            var message = await _organizationService.CheckCode(code);
            if (message == null)
            {
                return BadRequest("Invalid organization Code");
            }
            return Ok(message);
        }
        /// <summary>
        /// Get Organization With Hosts Url By Code For new SmartIn
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{code}")]
        public async Task<IActionResult> GetOrganizationWithHostsByCode(string code)
        {
            var organization = await _organizationService.GetOrganizationWithHostsByCode(code);
            if (organization == null)
            {
                return BadRequest("Invalid organization Code");
            }
            return Ok(organization);
        }
        /// <summary>
        /// get organization by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByOrganizationId()
        {
            var organization = await _organizationService.GetByOrganizationId();
            if (organization == null)
            {
                return BadRequest("Invalid organization Code");
            }
            return Ok(organization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _organizationService.Delete(id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationRequest(Guid id)
        {
            await _organizationService.DeleteOrganizationRequest(id);
            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> GenerateJsonFile(string code)
        {
            var stream = await _organizationService.GenerateJsonFile(code);
            return File(stream, "application/octet-stream");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        [HttpGet("{code}/{hash}")]
        [DisableRequestSizeLimit]
        public IActionResult DownLoadOrganizationServer(string code, bool hash)
        {
            var stream = _organizationService.DownLoadOrganizationServer(code, hash);
            if (stream != null)
            {
                return File(stream, "application/octet-stream");
            }
            else
                return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile()
        {
            var file = Request.Form.Files[0];
            var (result, message) = await _organizationService.UpdateOrganizationFromJsonFile(file);
            if (!string.IsNullOrWhiteSpace(message)) return BadRequest(message);
            return Ok(result);
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateOrganizationCrossCloudFromJsonFileForAum()
        {
            var file = Request.Form.Files[0];
            var (result, message) = await _organizationService.UpdateOrganizationCrossCloudFromJsonFile(file);
            if (!string.IsNullOrWhiteSpace(message)) return BadRequest(message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UploadFileLicence(JObject testobject)
        {
            var (result, message) = await _organizationService.UpdateOrganizationFromJsonFileLicence(testobject);
            if (!string.IsNullOrWhiteSpace(message)) return BadRequest(message);
            return Ok(result);
        }
        /// <summary>
        ///  Upload server license and encrypt it then download again
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadServerLicense([FromQuery] string organizationCode)
        {
            var file = Request.Form.Files[0];
            var stream = _organizationService.UploadServerLicenseFromJsonFile(file, organizationCode);
            return File(stream, "application/octet-stream");
        }


        /// <summary>
        ///  Upload server license and encrypt it then download again
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateAdminPasswordFile(PasswordConfirmationDto passwordConfirmationDto)
        {
            var stream = _organizationService.UpdateAdminPasswordFile(passwordConfirmationDto.Password);
            return File(stream, "application/octet-stream");
        }


        /// <summary>
        /// GetOrganizationCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrganizationCode(Guid id)
        {
            var organizationCode = await _organizationService.GetOrganizationCode(id);
            return Ok(organizationCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEncryption(Guid id)
        {
            return Ok(await _organizationService.VerifyEncryption(id));
        }

        [HttpGet]
        public async Task<IActionResult> OrganizationCount()
        {
            return Ok(await _organizationService.OrganizationCount());
        }
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetSettingActualWorking(Guid organizationId)
        {
            var organization = await _organizationService.GetSettingActualWorking(organizationId);
            return Ok(organization);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSettingActualWorkingAnonymous()
        {
            var organization = await _organizationService.GetSettingActualWorkingAnonymous();
            return Ok(organization);
        }
        [HttpGet("{packageId}")]
        public async Task<IActionResult> GetDropdownListModuleChecked(Guid packageId)
        {
            var organization = await _organizationService.GetDropdownListModuleChecked(packageId);
            return Ok(organization);
        }
        [HttpPost]
        public async Task<IActionResult> AddSettingActualWorking(List<SettingActualWorkingDto> settingActualWorkingDto)
        {
            var message = await _organizationService.AddSettingActualWorking(settingActualWorkingDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        [HttpGet("{organizaionId}")]
        public async Task<IActionResult> GetOrganizationIsShowWordAndExcel(Guid? organizaionId)
        {
            return Ok(await _organizationService.GetOrganizationIsShowWordAndExcel(organizaionId));
        }

        [HttpGet("{organizaionId}")]
        public async Task<IActionResult> GetOrganizationIsShowActualWorkingDay(Guid? organizaionId)
        {
            return Ok(await _organizationService.GetOrganizationIsShowActualWorkingDay(organizaionId));
        }
        [HttpGet("{organizaionId}")]
        public async Task<IActionResult> GetOrganizationIsAllowPasswordConstraints(Guid? organizaionId)
        {
            return Ok(await _organizationService.GetOrganizationIsAllowPasswordConstraints(organizaionId));
        } 
        [HttpGet("{organizaionId}")]
        public async Task<IActionResult> GetOrganizationIsUseOneDeviceForUserInquiry(Guid? organizaionId)
        {
            return Ok(await _organizationService.GetOrganizationIsUseOneDeviceForUserInquiry(organizaionId));
        }
        [HttpGet]
        public async Task<IActionResult> GetOrganizationsIdsList()
        {
            return Ok(await _organizationService.GetOrganizationIdsList());
        }
        [HttpGet]
        public IActionResult GetLogTypeMobileForOrganization()
        {
            return Ok(_organizationService.GetLogTypeMobileForOrganization());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationTimeZone(Guid id)
        {
            return Ok(await _organizationService.GetOrganizationTimeZone(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganizaionCloud()
        {
            var list = await _organizationService.GetAllOrganizaionCloud();
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetAllOrganizationTypeEnum()
        {
            var list =  _organizationService.GetAllOrganizationTypeEnum();
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizaionRequestCloud()
        {
            var list = await _organizationService.GetAllOrganizaionRequestCloud();
            return Ok(list);
        }      
        [HttpPost]
        public async Task<IActionResult> UpdateOrganizationCrossCloudFromJsonFile(JObject testobject)
        {
            var (result, message) = await _organizationService.UpdateOrganizationCrossCloudFromJsonFile(testobject);
            if (!string.IsNullOrWhiteSpace(message)) return BadRequest(message);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> IsOrganizaionCrossCloud()
        {
            return Ok(await _organizationService.IsOrganizaionCrossCloud());
        }
        [HttpGet]
        public async Task<IActionResult> IsOrganizaionCrossCloudClient()
        {
            return Ok(await _organizationService.IsOrganizaionCrossCloudClient());
        }
        [HttpGet("{orgId}")]
        public async Task<IActionResult> IsOrganizaionCrossCloudForAum(Guid orgId)
        {
            return Ok(await _organizationService.IsOrganizaionCrossCloudForAum(orgId));
        }
        [HttpGet("{orgId}")]
        public async Task<IActionResult> IsOrganizaionCrossCloudClientForAum(Guid orgId)
        {
            return Ok(await _organizationService.IsOrganizaionCrossCloudClientForAum(orgId));
        }
        // added by attaallah for test 

        [HttpGet]
        [AllowAnonymous]
        public string GenTo() => Helper.GenerateToken();
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllOrganizationIds()
        {
            return Ok(await _organizationService.GetAllOrganizationIds());
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult OrganizationType()
        {
            string? customLogin = _configuration["CustomLogin"];
            //var data = new
            //{
            //    message = ,
            //};
            return Ok(customLogin == null ? false : Convert.ToBoolean(customLogin)) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationSetting(Guid id) {
            return Ok(await _organizationService.GetOrganizationSetting(id));
        }
    }
}