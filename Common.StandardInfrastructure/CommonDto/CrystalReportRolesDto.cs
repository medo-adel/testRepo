using System;
using System.Collections.Generic;
using System.Text;

namespace Common.StandardInfrastructure.CommonDto
{

    public class CrystalReportScreenReportDto
    {
        public Guid ScreenId { get; set; }
        public string ScreenName { get; set; }
    }
    public class CrystalReportRolesDto
    {
        public List<Guid?> UserIds { get; set; }
        public List<CrystalReportScreenReportDto> ScreensReportsDto { get; set; }
        public Guid? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationLogo { get; set; }
        public string ScreenTitle { get; set; }
        public int PrintType { get; set; }
    }
}
