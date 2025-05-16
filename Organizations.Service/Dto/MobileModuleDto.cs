using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Service.Dto
{
   
    public class MobileModuleDto
    {
        public bool IsMyInquiry { get; set; } = false;
        public bool IsMyAdministration { get; set; } = false;
        public bool IsRequests { get; set; } = false;
        public bool IsSign { get; set; } = false;
        public bool IsDelgation { get; set; } = false;
        public bool IsFace { get; set; } = false;
        public MobileModuleRequestDto mobileModuleRequestDto { get; set; }
    }

    public class MobileModuleRequestDto
    {
        public bool IsPartDayPermission { get; set; } = false;
        public bool IsLeave { get; set; } = false;
        public bool IsFullDayPermission { get; set; } = false;
        public bool IsReturnLeave { get; set; } = false;
        public bool IsOverTime { get; set; } = false;
        public bool IsForgetSign { get; set; } = false;
        public bool IsAllowance { get; set; } = false;

        
    }
}
