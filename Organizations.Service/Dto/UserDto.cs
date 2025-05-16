using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class UserDto :BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
    public class AuthenticationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? OrganizationId { get; set; }
        public bool RememberMe { get; set; } = false;
        public bool IsMobileBrowser { get; set; } = false;
        public string Code { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
    
}
