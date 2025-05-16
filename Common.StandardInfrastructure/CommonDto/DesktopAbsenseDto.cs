using System;
using System.Collections.Generic;

namespace Common.StandardInfrastructure.CommonDto
{
    public class DesktopAbsenseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
