using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Organizations.Data.Entities.Base;

namespace Organizations.Data.Entities
{
    [Table("OrganizationScreens")]
    public class Screen : BaseModel
    {
        public string ComponentName { get; set; }
        public short OrderNumber { get; set; }
        public bool IsReport { get; set; }
        [StringLength(256)]
        public string UrlPath { get; set; }
        [StringLength(64)]
        public string IconName { get; set; }
        public bool CanShow { get; set; } = true;
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Screen Parent { get; set; }
        public virtual ICollection<Screen> Childerns { get; set; }
        public virtual List<ModuleScreen> ModuleScreens { get; set; }



    }
}
