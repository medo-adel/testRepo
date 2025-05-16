using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities
{
    [Table("OrganizationRoles")]
    public class Roles : BaseModel
    {
        public string RoleNameFl { get; set; }
        public string RoleNameSl { get; set; }

        public virtual List<UserRoles> UserRoles { get; set; }


    }
}
