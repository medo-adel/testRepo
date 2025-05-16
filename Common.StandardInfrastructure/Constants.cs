

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Common.StandardInfrastructure
{
    public static class Constants
    {

        //Controller
        public const string EmployeesController = "Employees/";

        //actions
        public const string GetPredicateWithOrder = "GetPredicateWithOrder";

        public const string ExcelExtensionAcceptOldVersion = ".xls";
        public const string ExcelExtensionAcceptNewVersion = ".xlsx";
        public const string LogFileFolderName = "LogFile";
        public const string EncryptDecryptKey = "dNNPiSXzbLgFFmqLJ9GBnyK5fgBjfFNF";
        public static List<string> PropertiesList = new List<string>() { "OrganizationId", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" };
        ////NotificationsUrl -- MyRequest
        //public const string RequesterMyPermissionUrl = "/main/my-request/permission-tabs/permission-tabs/permission-request-details/";
        //public const string RequesterMyLeaveUrl = "/main/my-request/leave-tabs/leave-tabs/leave-request-details/";
        //public const string RequesterMyLeaveReturnUrl = "/main/my-request/return-leave-tabs/return-leave-tabs/return-leave-details/";
        //public const string RequesterMyOverTimeUrl = "/main/my-request/overtime-tabs/overtime-tabs/overtime-request-details/";
        //public const string RequesterMyFullDayPermissionUrl = "/main/my-request/full-day-permission-tabs/full-day-permission-tabs/full-day-request-details/";

        ////NotificationsUrl -- Request 
        //public const string ApproverPermissionUrl = "/main/request/permission-tabs/permission-tabs/approve-permission-request/";
        //public const string ApproverLeaveUrl = "/main/request/leave-tabs/leave-tabs/approve-leave-request/";
        //public const string ApproverLeaveReturnUrl = "/main/request/return-leave-tabs/return-leave-tabs/approve-return-leave-request/";
        //public const string ApproverOverTimeUrl = "/main/request/overtime-tabs/overtime-tabs/approve-overtime-request/";
        //public const string ApproverFullDayPermissionUrl = "/main/request/full-day-permission-tabs/full-day-permission-tabs/approve-full-day-permission-request/";

        //NotificationsUrl -- MyRequest New
        public const string RequesterMyPermissionUrl = "/home/myRequests/part-day/permission-request-details/";
        public const string RequesterMyLeaveUrl = "/home/myRequests/request-leave/leave-request-details/";
        public const string RequesterMyLeaveReturnUrl = "/home/myRequests/return-from-leave/return-leave-request-details/";
        public const string RequesterMyOverTimeUrl = "/home/myRequests/over-time/overtime-request-details/";                                                      
        public const string RequesterMyFullDayPermissionUrl = "/home/myRequests/full-day/full-day-request-details/";
        public const string RequesterMyForgetSignUrl = "/home/myRequests/forget-sign/forget-sign-request-details/";
        public const string RequesterMyAllowanceUrl = "/home/myRequests/allowance/allowance-request-details/";

        //NotificationsUrl -- Request New
        public const string ApproverPermissionUrl = "/home/requests/manager-part-day/approve-permission-request/";
        public const string ApproverLeaveUrl = "/home/requests/manager-leave/approve-leave-request/";
        public const string ApproverLeaveReturnUrl = "/home/requests/manager-return-leave/approve-return-leave-request/";
        public const string ApproverOverTimeUrl = "/home/requests/manager-over-time/approve-overtime-request/";
        public const string ApproverFullDayPermissionUrl = "/home/requests/manager-full-day/approve-full-day-permission-request/";
        public const string ApproverForgetSignUrl = "/home/requests/manager-forget-sign/approve-forget-sign-request/";
        public const string ApproverAllowanceUrl = "/home/requests/manager-allowance/approve-allowance-request/";

        #region FolderNameList
        public const string FilesFolder = "Files/";
        public const string EmployeesFolder = "Files/Employees/";
        public const string IconFolder = "Files/Icon/";
        public const string EmployeeAllowanceFolder = "Files/EmployeeAllowance/";
        public const string EmployeeAttendanceLogsFolder = "Files/Logs/";
        public const string EmployeeLeaveFolder = "Files/EmployeeLeave/";
        public const string EmployeeDeviceLogMobileFolder = "Files/Logs/";
        public const string EmployeePermissionFolder = "Files/EmployeePermission/";
        public const string FullDayPermissionFolder = "Files/FullDayPermission/";
        public const string OverTimeFolder = "Files/OverTime/";

        #endregion

    }
}
