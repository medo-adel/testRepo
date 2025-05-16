using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto.OtherServices
{
    public class AdminUserDto
    {
        public Guid Id { get; set; }
        public Guid? OrganizationId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime ExpireDate { get; set; }

        public bool IsEndOfContract { get; set; }
        public bool IsActive { get; set; }
        public bool IsCivilId { get; set; }

        public string IsSuperAdmin { get; set; }
    }
}
