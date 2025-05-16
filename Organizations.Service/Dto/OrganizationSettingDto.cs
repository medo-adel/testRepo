using Organizations.Service.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
  public  class OrganizationSettingDto : BaseDto
    {
        public Guid OrganizationId { get; set; }       
        public Guid NationalityId { get; set; }
        public bool? IsActiveDirectory { get; set; } = false;
        public string AdDomainName { get; set; }
        public Guid? PrimaryKeyId { get; set; } = Guid.Empty;        
        public Guid? ADKeyId { get; set; } = Guid.Empty;
        public Guid? RestDayId { get; set; }
        public Guid? WeekendDayId { get; set; }
        public bool? IsReviewLogs { get; set; }
        public bool? IsShowWordAndExcel { get; set; } = false;
        public int? MaxNumberofPermissionTimes { get; set; } = 0;
        public int? MaxNumberofPermissionTimesPerDay { get; set; } = 0;
        public int? TotalMinutesFromParkingToOffice { get; set; }
        public Guid? LogTypeMobileId { get; set; }
        public bool? IsShowActualWorkingDay { get; set; } = false;
        public bool? AllowPasswordConstraints { get; set; } = false;
        public bool? IsMangerAssignDelegate { get; set; } = false;       
        public int? NumberDayOfLeave { get; set; }
        public Guid? LeaveRegulationId { get; set; }
        public bool? UseOneDeviceForUserInquiry { get; set; }
        public bool? IsThirdSign { get; set; }
        public double? TimeSendNotification { get; set; }
        public double? PermisionTimeForThirdSign { get; set; }
        public bool? IsCalulteThirdSignFromExpectitedTime { get; set; }
        public DateTime? DateExecutedThirdSign { get; set; }
        public double? CountOfSecondsToCheckLiveness { get; set; }
        public double? LivenessLevelOptions { get; set; }
        public bool? SendNotificationLogBeforeAfterDuty { get; set; } = false;
    }
}
