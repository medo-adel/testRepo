using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities
{
    [Table("OrganizationUsers")]
    public  class User :BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime SessionEndTime { get; set; }
        public virtual List<UserRoles> UserRoles { get; set; }

    }
}
