using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Service.Dto
{
    public class TimeZonesDto : BaseDto
    {
        public string Name { get; set; }
        public string TimeZone { get; set; }
    }
}
