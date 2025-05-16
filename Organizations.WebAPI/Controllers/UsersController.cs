using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizations.Service.Dto;
using Organizations.Service.Interfaces;
using Organizations.WebAPI.Controllers.Base;

namespace Organizations.WebAPI.Controllers
{
    /// <inheritdoc />
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        /// <inheritdoc />
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Authenticate function responsible for user login schema
        /// </summary>
        /// <param name="userDto">username and password</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(UserDto userDto)
        {
            var result = await _userService.Authenticate(userDto);

            if (result.Token == null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        /// <summary>
        /// Used to change password for user
        /// </summary>
        /// <param name="ChangePasswordDto">Contain current password and new password parameters</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto ChangePasswordDto)
        {
            if (await _userService.ChangePassword(ChangePasswordDto))
                return Ok();
            else return BadRequest("Your current password is incorrect!");
        }
        /// <summary>
        /// Forget Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        [HttpGet("{email}")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var res = await _userService.CanSendEmailForUser(email);
            if (res == null) return Ok();
            return BadRequest(res);
        }
      
          
    }
    }