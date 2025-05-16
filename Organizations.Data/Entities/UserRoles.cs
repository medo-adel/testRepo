using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities
{
    [Table("OrganizationUserRoles")]
    public class UserRoles : BaseModel
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
