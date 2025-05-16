using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class UserMangmentDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<UserRoleDto> UserRoles { get; set; }

    }
}
