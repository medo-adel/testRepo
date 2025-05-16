using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.StandardInfrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organizations.Service.Dto;
using Organizations.Service.FilterDto;
using Organizations.Service.Interfaces;
using Organizations.WebAPI.Controllers.Base;

namespace Organizations.WebAPI.Controllers
{
    /// <inheritdoc />
    public class UserMangmentsController : BaseController
    {
        private readonly IUserManagementService _userManagementService;

        /// <inheritdoc />
        public UserMangmentsController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filteringDto"></param>
        /// <param name="pagingSortingDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetAllPaged([FromBody] UserMangmentFilterDto filteringDto, [FromQuery] PagingSortingDto pagingSortingDto)
        {
            var list = await _userManagementService.GetAllUserManagementPaged(filteringDto, pagingSortingDto);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserMangmentDto userManagementDto)
        {
            var message = await _userManagementService.Add(userManagementDto);
            if (string.IsNullOrWhiteSpace(message)) return Ok();
            return BadRequest(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var userManagement = await _userManagementService.Get(id);
            return Ok(userManagement);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManagementDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UserMangmentDto userManagementDto)
        {
            await _userManagementService.Update(userManagementDto);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_userManagementService.ReturenUserIdToken() == id)
            {
                return BadRequest("This User Is Logining Now ");
            }
            await _userManagementService.Delete(id);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userManagementService.GetAll();

            return Ok(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var list = await _userManagementService.GetAllRoles();

            return Ok(list);
        }
    }
}