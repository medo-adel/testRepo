using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.StandardInfrastructure.CommonDto
{
    public class ReportResult
    {
        public ReportFilterDto ReportFilter{ get; set; }
        public List<object> Data { get; set; } = new List<object>();

    }
}