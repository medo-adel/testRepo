using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Service.Dto
{
  public  class SettingActualWorkingDto : BaseDto
    {
        public Guid TransactionId { get; set; }
        public Guid TypeId { get; set; }
        public Guid? OrganizationId { get; set; }


    }
}
