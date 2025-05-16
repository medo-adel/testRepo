using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Data.Entities
{
   public class ModuleScreen :BaseModel
    {
        public Guid ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public Guid ScreenId { get; set; }
        public virtual Screen Screen { get; set; }

    }
}
