using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Data.Entities
{
   public class SettingActualWorking : BaseModel
    {
        public Guid TransactionId { get; set; }
        public Guid TypeId { get; set; }
        public Guid? OrganizationId { get; set; }
   
    }
}
