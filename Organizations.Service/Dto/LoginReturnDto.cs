using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class LoginReturnDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
