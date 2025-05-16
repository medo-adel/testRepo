using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Organizations.Data.Entities {
  public  class OrganizationSetting : BaseModel {
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public Guid NationalityId { get; set; }
        public bool? IsActiveDirectory { get; set; }
        public string AdDomainName { get; set; }
        public Guid RestDayId { get; set; }
        public Guid WeekendDayId { get; set; }
        public Guid? PrimaryKeyId { get; set; }
        [ForeignKey("PrimaryKeyId")]
        public virtual ActiveDirectoryPrimaryKey ActiveDirectoryPrimaryKey { get; set; }
        public Guid? ADKeyId { get; set; }
        [ForeignKey("ADKeyId")]
        public virtual ActiveDirectoryKey ActiveDirectoryKey { get; set; }
        [DefaultValue("True")]
        public bool? IsReviewLogs { get; set; }
        public bool? IsShowWordAndExcel { get; set; } = false;
        [DefaultValue(0)]
        public int? MaxNumberofPermissionTimes { get; set; }      
        public int? MaxNumberofPermissionTimesPerDay { get; set; }
        public int? TotalMinutesFromParkingToOffice { get; set; }
        public Guid? LogTypeMobileId { get; set; }
        public bool? IsShowActualWorkingDay { get; set; } = false;
        public bool? AllowPasswordConstraints { get; set; } = false;
        public bool? IsMangerAssignDelegate { get; set; }
        public int? NumberDayOfLeave { get; set; }
        public Guid? LeaveRegulationId { get; set; }
        public bool? UseOneDeviceForUserInquiry { get; set; }
        public bool? IsThirdSign { get; set; }
        public double? TimeSendNotification { get; set; }
        public double? PermisionTimeForThirdSign { get; set; }
        public bool? IsCalulteThirdSignFromExpectitedTime { get; set; } = false;
        public DateTime? DateExecutedThirdSign { get; set; }
        public int? CountOfSecondsToCheckLiveness { get; set; }
        public int? LivenessLevelOptions { get; set; }
        public bool? SendNotificationLogBeforeAfterDuty { get; set; } = false;
    }
}
