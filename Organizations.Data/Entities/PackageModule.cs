using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
   public class PackageModule : BaseModel
    {
        public Guid ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public Guid PackageId { get; set; }
        public virtual Package Package { get; set; }
        public bool? IsChecked { get; set; }

    }
}
