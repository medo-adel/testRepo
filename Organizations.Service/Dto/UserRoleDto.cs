using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class UserRoleDto
    {
        public string RoleNameFl { get; set; }
        public string RoleNameSl { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
    
}
