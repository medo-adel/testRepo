﻿using System;
using System.Collections.Generic;
using System.Reflection;
// ReSharper disable StringLiteralTypo
namespace Common.StandardInfrastructure
{
    public enum OutBoxStatus
    {
        DeleteCreate = 0, Create = 1, Update = 2, delete = 3,
    }
    public enum CommuncationDecision
    {
        Org = 1,
        Crystal,
        TamsUrl,
        AumUrl,
        External
    }
    public enum Audit_ActionEnum
    {
        Add = 1,
        Update = 2,
        Delete = 3,
        Remove = 4,
        AddRange = 5,
        DeleteRange = 6

    }
    public enum Filter_GridEnum
    {
        Contains = 0,
        StartWith = 1,
        EndWith = 2,
        Equal = 3
    }

    public enum StageTypeEnum
    {
        Administration = 0,
        Team = 1
    }
    public enum LocationProofEnum
    {
        Point = 0,
        Polygon = 1,
        Beacon = 2
    }
    public enum NotificationStateTypeEnum
    {
        Previous = 0,
        Next = 1
    }
    public enum TriggerType
    {


        F1 = 1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        UNKNOWN,
        IN,
        OUT,
        IDUNKNOWN,
        REJECTED,
        IDRESERVED,
        RESETALL,
        RESETACC,
        RESETDEVICE,
        RESETPASSWORD,
        RESETDEFAULT,
        SYSTEMLOGIN,
        ADMINLOGIN,
        USERLOGIN,
        NETWORKCHANGE,
        PATCHED,
        BACKUPDB,
        RESTOREDB,
        SYSTEMRSVD,
        ENROLLUSER,
        REMOTEDOOROPEN,
        REMOVEUSER,
        SUSPENDUSER,
        EDITEVENT,
        RESETADMINPW,
        ADMINRSVDIT,
        F11,
        F12,
        F13,
        F14,
        F15,
        F16,
        F17,
        F18,
        F19,
        F20,
        F21,
        F22,
        F23,
        F24,
        F25,
        F26,
        F27,
        F28,
        F29,
        F30,
        F31,
        F32,
        F33,
        F34,
        F35,
        F36,
        F37,
        F38,
        F39,
        F40
            ,
        SCHEDULEDOOROPEN,
        SCHEDULEDOORCLOSE,
        SCHEDULEBELLON,
        DOORISOPENED,
        DOORISCLOSED,
        CASEISOPENED,
        CASEISCLOSED,
        TRIGGEREND,
    }

    public enum ActionServiceEnum
    {
        Map = 0,
        Success = 1,
        AlreadyExist = 2,
        TerminalNotAdd = 3,
        EventIdError = 4

    }

    public enum Deduction_CategoryEnum
    {
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C695")]
        [EnumStringNameValue("Multiplier", "متضاعفة")]
        Multiplier = 1,
        [EnumGuid("5c60f693-bef5-e011-a485-80ee7300c696")]
        [EnumStringNameValue("Period", "فترات")]
        Period = 2
    }
    public enum Deduction_Group_TypesEnum
    {
        [EnumGuid("5c60f693-bef5-e011-a485-80ee7300c695")]
        [EnumStringNameValue("Contracts", "نوع العقد")]
        Contracts = 1,
        [EnumGuid("5c60f693-bef5-e011-a485-80ee7300c696")]
        [EnumStringNameValue("All Employees", "كل الموظفين")]
        AllEmployees = 2,
        [EnumGuid("5c60f693-bef5-e011-a485-80ee7300c697")]
        [EnumStringNameValue("Old Employees", "قدامى الموظفين")]
        OldEmployees = 3
    }
    public enum DeductionUnitEnum
    {
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C695")]
        [EnumStringNameValue("Quarter Of Day", "ربع يوم")]
        QuarterDay = 1,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C696")]
        [EnumStringNameValue("Half Day", "نصف يوم")]
        HalfDay = 2,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C697")]
        [EnumStringNameValue("3/4 Day", "3/4 يوم")]
        ThreequartersDay = 3,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C698")]
        [EnumStringNameValue("Full Day", "يوم كامل")]
        Fullday = 4
    }
    public enum EmployeeProfileEnum
    {
        Adminstration = 0,
        TemporaryAdmistration = 1,
        Location = 2,
        ContractType = 3,
        Job = 4,
        JobDegree = 5
    }

    public enum BalanceTypeEnum
    {
        Fixed = 1,
        Period = 2,
        JobDegree = 3
    }

    public enum ValidLogStatusEnum
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3
    }

    public enum FinalStatusEnum
    {
        Pending = 1,
        Approval = 2,
        Rejected = 3,
        Removed = 4
    }


    public enum ChangePasswordEnum
    {
        ErrorPassword = 0,
        Approval = 1,
        PasswordHistoryError = 2,
        TimeChangeError = 3
    }

    public enum BalancePeriodEnum
    {
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("100", "100")]
        A100,
        [EnumGuid("5160F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("75", "75")]
        A75,
        [EnumGuid("2260F693-BEF5-E011-A485-80EE7300C693")]
        [EnumStringNameValue("50", "50")]
        A50,
        [EnumGuid("4260F693-BEF5-E011-A485-80EE7300C694")]
        [EnumStringNameValue("25", "25")]
        A25,
        [EnumGuid("3260F693-BEF5-E011-A485-80EE7300C699")]
        [EnumStringNameValue("0", "0")]
        A0,
    }
    public enum PermissionTimeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Start Duty", "بداية الدوام")]
        Start,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("During Duty", "اثناء الدوام")]
        During,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("End Duty", "نهاية الدوام")]
        End
    }


    public enum RolesEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Admin", "Admin")]
        Admin,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("User", "User")]
        User,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Techincal support", "Techincal support")]
        Tech,
    }
    public enum OrganizationTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Cross Cloud", "Cross Cloud")]
        CrossCloud,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Cross Cloud Client", "Cross Cloud Client")]
        CrossCloudClient,
    }
    public enum LogTypeMobileForOrganizationEnum
    {
        [EnumGuid("60000000-6000-6000-6000-600000000000")]
        [EnumStringNameValue("F1", "F1")]
        F1,
        [EnumGuid("70000000-7000-7000-7000-700000000000")]
        [EnumStringNameValue("F2", "F2")]
        F2,
        [EnumGuid("80000000-8000-8000-8000-600000000000")]
        [EnumStringNameValue("F3", "F3")]
        F3,
        [EnumGuid("90000000-9000-9000-9000-900000000000")]
        [EnumStringNameValue("F4", "F4")]
        F4
    }
    public enum AttachmentsTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("None", "لا شئ")]
        None,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Optional", "إختياري")]
        Optional,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Mandatory", "إجباري")]
        Mandatory
    }
    public enum ActiveDirectoryPrimaryKeyEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("CivilId", "الرقم المدني")]
        CivilId,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("EmployeeNumber", "رقم الموظف")]
        EmployeeNumber
    }

    public enum ActiveDirectoryKeyEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Attribute1", "Attribute1")]
        Attribute1,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Attribute2", "Attribute2")]
        Attribute2
    }
    public enum DutyTypesEnum
    {
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("Fixed Duty", "دوام ثابت")]
        Fixed,
        [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("Fixed Period Duty", "دوام الفتره الثابته")]
        FixedPeriod,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
        [EnumStringNameValue("Free Duty", "دوام حر")]
        Free,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C614")]
        [EnumStringNameValue("Hourly Rotated Duty", "دوام متعاقب بالساعة")]
        Hourly,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C615")]
        [EnumStringNameValue("Daily Rotated Duty", "دوام متعاقب باليوم")]
        Daily
    }
    //public enum RemarksEnum
    //{
    //    [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
    //    [EnumStringNameValue("Manual", "يدوي")]
    //    Manual,
    //    [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
    //    [EnumStringNameValue("Excel Sheet", "اكسيل شيت")]
    //    Sheet,
    //    [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
    //    [EnumStringNameValue("Password", "الرقم السري")]
    //    Password,
    //    [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C614")]
    //    [EnumStringNameValue("Card", "كارت")]
    //    Card,
    //    [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C615")]
    //    [EnumStringNameValue("Finger", "بصمه الاصبع")]
    //    Finger,
    //    [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C616")]
    //    [EnumStringNameValue("Face", "وجه")]
    //    Face,
    //    [EnumGuid("1360f693-bef5-e011-a485-80ee7300c617")]
    //    [EnumStringNameValue("Mobile", "محمول")]
    //    Mobile

    //}
    public enum RemarksEnum
    {
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("Manual", "يدوي")]
        Manual,
        [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("Excel Sheet", "اكسيل شيت")]
        Sheet,
        [EnumGuid("1360f693-bef5-e011-a485-80ee7300c617")]
        [EnumStringNameValue("Mobile Log", "محمول بصمة")]
        Mobile,
        [EnumGuid("1360f693-bef5-e011-a485-80ee7300c619")]
        [EnumStringNameValue("Mobile Face", "محمول وجه")]
        MobileFace,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C616")]
        [EnumStringNameValue("Device", "جهاز بصمة")]
        Device
    }
    public enum AccessMethodsEnum
    {
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
        [EnumStringNameValue("Password", "الرقم السري", "PWD")]
        Password,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C614")]
        [EnumStringNameValue("Card", "كارت", "SMC")]
        Card,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C615")]
        [EnumStringNameValue("Finger", "بصمه الاصبع", "FP")]
        Finger,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C616")]
        [EnumStringNameValue("Face", "وجه", "FACE")]
        Face,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C616")]
        [EnumStringNameValue("Manual", "يدوي", "MNL")]
        Manual,
    }

    public enum FixedDutyPeriodEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Rest Day", "يوم الراحه")]
        RestDay,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Week End", "نهايه الاسبوع")]
        WeekEnd,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Leave", "اجازة")]
        Leave
    }
    public enum EmergencyAllowanceDescriptionTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Location", "موقع")]
        Location,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Administrative level", "إدارة")]
        AdministrativeLevel
    }
    public enum AllowanceTypeEnum
    {
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C694")]
        [EnumStringNameValue("Exemption sign In", "إعفاء من توقيع الحضور")]
        ExemptionSignIn,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C695")]
        [EnumStringNameValue("Exemption Sign Out ", "اعفاء من توقيع انصراف")]
        ExemptionSignOut,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C699")]
        [EnumStringNameValue("Exemption In & Out ", "اعفاء حضور وانصراف")]
        ExemptionInOut,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C696")]
        [EnumStringNameValue("Allowance sign In", "سماحية حضور")]
        AllowanceSignIn,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C697")]
        [EnumStringNameValue("Allowance sign Out", "سماحية إنصراف")]
        AllowanceSignOut,
        [EnumGuid("5C60F693-BEF5-E011-A485-80EE7300C698")]
        [EnumStringNameValue("Allowance In & Out", "سماحية حضور و انصراف")]
        AllowanceInOut,
    }
    public enum UserNameTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("CivilId", "الرقم القومي")]
        CivilId,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Employee Number", "رقم الموظف ")]
        EmployeeNumber,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Other", "اخري")]
        Other
    }
    public enum SyncLogsExceptionsTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("User", "مستخدم")]
        User,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Trigger", "حركة")]
        Trigger,

    }
    public enum TransferredDepartmentEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("First Department", "أول اداره")]
        FirstDepartment,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Last Department", "أخر اداره")]
        LastDepartment,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Longest Duration", "الاكثر مده")]
        LongestDuration,

    }
    public enum LogTypeEnum
    {
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Rejected", "مرفوضه")]
        Rejected,
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("IN", "دخول")]
        IN,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("OUT", "خروج")]
        OUT,
        [EnumGuid("60000000-6000-6000-6000-600000000000")]
        [EnumStringNameValue("F1", "F1")]
        F1,
        [EnumGuid("70000000-7000-7000-7000-700000000000")]
        [EnumStringNameValue("F2", "F2")]
        F2,
        [EnumGuid("80000000-8000-8000-8000-600000000000")]
        [EnumStringNameValue("F3", "F3")]
        F3,
        [EnumGuid("90000000-9000-9000-9000-900000000000")]
        [EnumStringNameValue("F4", "F4")]
        F4
    }

    public enum SignType
    {
        GPS = 1,
        Beacon,
        None,
        All,
        Wifi,

    }
    public enum SalaryLeaveEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("UnDefined", "غير محدد")]
        UnDefined,
        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("With Leave", "مع الاجازه")]
        WithLeave,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Before leave", "قبل الاجازه")]
        Before,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("After leave", "بعد الاجازه")]
        After,


    }

    public enum ServiceStatusEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("In Service", "في الخدمه ")]
        OnDuty,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Out Of Service", "خارج الخدمه")]
        OutOfDuty,
    }
    public enum EmployeeServicesStatusEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("In Service", "في الخدمه ")]
        InService,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Retirement", "تقاعد")]
        Retirement,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Resignation", "استقالة")]
        Resignation,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Scarontheotherhand", "ندب من جهةاخري")]
        Scarontheotherhand,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Death", "وفاة")]
        Death,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Transport services", "نقل خدمات")]
        Transportservices,

    }
    public enum DayTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Work Day", "يوم عمل  ")]
        WorkDay,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Rest Day", "يوم راحه")]
        RestDay,

    }
    public enum MartialStatusEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Married", "متزوج")]
        Married,

        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Single", "أعزب")]
        Single,

        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Widowed", "أرمل")]
        Widowed,

        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Divorced", "مطلق")]
        Divorced,

        [EnumGuid("50000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Un Defined", "غير معرف")]
        UnDefined,
    }

    public enum GenderEnum
    {
        [EnumGuid("1160f693-bef5-e011-a485-80ee7300c611")]
        [EnumStringNameValue("Male", "ذكر")]
        Male,
        [EnumGuid("5160f693-bef5-e011-a485-80ee7300c612")]
        [EnumStringNameValue("Female", "أنثي")]
        Female,
        [EnumGuid("2260f693-bef5-e011-a485-80ee7300c693")]
        [EnumStringNameValue("Both", "كلاهما")]
        Both
    }

    public enum ModelEnum
    {
        [EnumGuid("1160f693-bef5-e011-a485-80ee7300c622")]
        [EnumStringNameValue("Children Bonus Decision", "قرار علاوة ابناء")]
        ChildrenBonus,
        [EnumGuid("5160f693-bef5-e011-a485-80ee7300c633")]
        [EnumStringNameValue("Marriage Bonus Decision", "قرار علاوة زوجية")]
        MarriageBonus,
        [EnumGuid("2260f693-bef5-e011-a485-80ee7300c644")]
        [EnumStringNameValue("Motherhood Decision", "قرار امومة")]
        MotherhoodDecision,
        [EnumGuid("2260f693-bef5-e011-a485-80ee7300c655")]
        [EnumStringNameValue("Job Upgrade Decision", "قرار رفع مستوي الوظيفة")]
        JobUpgradeDecision
    }
    public enum WeekDaysEnum
    {
        [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("Sunday", "الاحد")]
        Sunday,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
        [EnumStringNameValue("Monday", "الاثنين")]
        Monday,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C614")]
        [EnumStringNameValue("Tuesday", "الثلاثاء")]
        Tuesday,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C615")]
        [EnumStringNameValue("Wednesday", "الاربعاء")]
        Wednesday,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C616")]
        [EnumStringNameValue("Thursday", "الخميس")]
        Thursday,
        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C618")]
        [EnumStringNameValue("Friday", "الجمعه")]
        Friday,
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("Saturday", "السبت")]
        Saturday,
    }

    public enum DutyStatusEnum
    {
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("Basic", "اساسي")]
        Basic,

        [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("Temporary", "مؤقت")]
        Temporary,

        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
        [EnumStringNameValue("Ramadan", "رمضان")]
        Ramadan
    }
    public enum EmployeeStatusEnum
    {
        [EnumGuid("00000000-0000-0000-0000-000000000001")]
        [EnumStringNameValue("Present", "حضور", true, true)]
        Present = 1,
        [EnumGuid("00000000-0000-0000-0000-000000000002")]
        [EnumStringNameValue("NoSignIn", "عدم توقيع حضور", true, true)]
        NoSignIn,
        [EnumGuid("00000000-0000-0000-0000-000000000003")]
        [EnumStringNameValue("NoSignOut", "عدم توقيع انصراف", true, true)]
        NoSignOut,
        [EnumGuid("00000000-0000-0000-0000-000000000004")]
        [EnumStringNameValue("Exemption In", "اعفاء حضور", false, true)]
        ExemptionIn,
        [EnumGuid("00000000-0000-0000-0000-000000000005")]
        [EnumStringNameValue("Exemption Out", "اعفاء انصراف", false, true)]
        ExemptionOut,
        [EnumGuid("00000000-0000-0000-0000-000000000006")]
        [EnumStringNameValue("Exemption In&out", "اعفاء حضور وانصراف", false, true)]
        ExemptionInOut,
        [EnumGuid("00000000-0000-0000-0000-000000000007")]
        [EnumStringNameValue("Emergency", "اعفاء طارئ", true, true)]
        EmergencyAllowance,
        [EnumGuid("00000000-0000-0000-0000-000000000008")]
        [EnumStringNameValue("Leaves", "اجازة", false, true)]
        Vacation,
        [EnumGuid("00000000-0000-0000-0000-000000000009")]
        [EnumStringNameValue("Weekend", "نهاية الاسبوع", false, true)]
        Weekend,
        [EnumGuid("00000000-0000-0000-0000-000000000010")]
        [EnumStringNameValue("RestDay", "راحة", false, true)]
        RestDay,
        [EnumGuid("00000000-0000-0000-0000-000000000011")]
        [EnumStringNameValue("Absence", "غياب", true, true)]
        Absence,
        [EnumGuid("00000000-0000-0000-0000-000000000012")]
        [EnumStringNameValue("Late", "تاخير", true, true)]
        Late,
        [EnumGuid("00000000-0000-0000-0000-000000000013")]
        [EnumStringNameValue("Holiday", "عطلة رسمية", false, true)]
        Holiday,
        [EnumGuid("00000000-0000-0000-0000-000000000014")]
        [EnumStringNameValue("FullDay Permission", "تصريح يوم كامل", false, true)]
        FullDayPermission,
        [EnumGuid("00000000-0000-0000-0000-000000000015")]
        [EnumStringNameValue("Permission", "استئذان", false, true)]
        Permission,
        [EnumGuid("00000000-0000-0000-0000-000000000016")]
        [EnumStringNameValue("Overtime", "وقت اضافي", false, true)]
        Overtime,
        [EnumGuid("00000000-0000-0000-0000-000000000017")]
        [EnumStringNameValue("Duty not started yet", "الدوام لم يبدا بعد", false, false)]
        DutyNotStart,
        [EnumGuid("00000000-0000-0000-0000-000000000018")]
        [EnumStringNameValue("In Duty now", "الان بالدوام", false, false)]
        ThrowDuty,
        [EnumGuid("00000000-0000-0000-0000-000000000019")]
        [EnumStringNameValue("Allowance In", "سماحية حضور", false, true)]
        AllowanceIn,
        [EnumGuid("00000000-0000-0000-0000-000000000020")]
        [EnumStringNameValue("Allowance Out", "سماحية انصراف", false, true)]
        AllowanceOut,
        [EnumGuid("00000000-0000-0000-0000-000000000021")]
        [EnumStringNameValue("Allowance In&Out", "سماحية حضور وانصراف", false, true)]
        AllowanceInOut,
        [EnumGuid("00000000-0000-0000-0000-000000000022")]
        [EnumStringNameValue("Nosign at rest", "عدم توقيع وقت الراحة", true, true)]
        BreakNoSign,
        [EnumGuid("00000000-0000-0000-0000-000000000023")]
        [EnumStringNameValue("Exemption from sign", "إعفاء من البصمة", false, false)]
        SignExemption,
        [EnumGuid("00000000-0000-0000-0000-000000000024")]
        [EnumStringNameValue("OutOfWork", "انقطاع عن العمل", false, true)]
        OutOfWork,
    }


    public enum ShiftSummaryEnum
    {
        FirstDuty = 1,
        SecoundDuty = 2,
        ThirthDuty = 3,
        FourthDuty = 4,
        FifthDuty = 5,
        SixthDuty = 6,
        SeventhDuty = 7,
        EighthDuty = 8,
    }
    public enum CalculationTypes
    {
        Creation = 1,
        Verification,
        Validation
    }
    public enum BalanceCaluculationWayEnum
    {
        [EnumGuid("3460F693-BEF5-E011-A485-80EE7300C692")]
        [EnumStringNameValue("Monthly", "مع بدايه كل شهر")]
        Monthly,
        [EnumGuid("0a61cff2-32fb-4488-8be0-555bda4571db")]
        [EnumStringNameValue("daily", "تراكمي بشكل يومي")]
        Daily,

        [EnumGuid("4360F693-BEF5-E011-A485-80EE7300C697")]
        [EnumStringNameValue("Annual", "مع بداية كل عام")]
        Annual,

        [EnumGuid("5360f693-bef5-e011-a485-80ee7300c698")]
        [EnumStringNameValue("Non Cumulative", "غير تراكمي")]
        NonCumulative

    }

    public enum OverTimeTypeEnum
    {
        [EnumGuid("1160F693-BEF5-E011-A485-80EE7300C611")]
        [EnumStringNameValue("Morning", "صباحي")]
        Morning,

        [EnumGuid("1260F693-BEF5-E011-A485-80EE7300C612")]
        [EnumStringNameValue("Night", "مسائي")]
        Night,

        [EnumGuid("1360F693-BEF5-E011-A485-80EE7300C613")]
        [EnumStringNameValue("Weekend", "نهاية أسبوع")]
        Weekend,

        [EnumGuid("1460F693-BEF5-E011-A485-80EE7300C614")]
        [EnumStringNameValue("Holiday", "عطلة")]
        Holiday,
        [EnumGuid("1460F693-BEF5-E011-A485-80EE7300C615")]
        [EnumStringNameValue("FullDayPermission", "تصريح يوم كامل")]
        FullDayPermission,
        [EnumGuid("1460F693-BEF5-E011-A485-80EE7300C616")]
        [EnumStringNameValue("Allowance", "اعفاء")]
        Allowance
    }

    public enum WorkflowStatusEnum
    {
        [EnumGuid("40144a96-b6b3-4aae-bb68-3a9d27c580e6")]
        [EnumStringNameValue("New Request", "طلب جديد")]
        NewRequest,



        [EnumGuid("8441f18d-17ba-4974-9f8b-d74472f8150d")]
        [EnumStringNameValue("Waiting for approval", "في انتظار الموافقة")]
        WaitingForApproval,

        [EnumGuid("1e99618b-6294-4786-8b00-2b8e294c66fe")]
        [EnumStringNameValue("Approved", "مقبول")]
        Approved,

        [EnumGuid("b71721e6-eed9-438c-a7d4-a3ff40647f56")]
        [EnumStringNameValue("Rejected", "مرفوض")]
        Rejected,

        [EnumGuid("971721e6-eed9-438c-a7d4-a3ff40647f67")]
        [EnumStringNameValue("Removed", "محذوف")]
        Removed,
        [EnumGuid("971721e6-eed9-438c-a7d4-a3ff40648f68")]
        [EnumStringNameValue("Posted", "مرحل")]
        Posted
    }
    public enum ApplicationsEnum
    {
        [EnumGuid("40144a96-b6b3-4aae-bb68-3a9d27c580e6")]
        [EnumStringNameValue("Tams", "Tams")]
        Tams,

        [EnumGuid("8441f18d-17ba-4974-9f8b-d74472f8150d")]
        [EnumStringNameValue("Mobile", "Mobile")]
        Mobile,

        [EnumGuid("1e99618b-6294-4786-8b00-2b8e294c66fe")]
        [EnumStringNameValue("Aum", "Aum")]
        Aum,


    }


    public enum RequestTypeEnum
    {
        [EnumGuid("40144a96-b6b3-4aae-bb68-3a9d27c58011")]
        [EnumStringNameValue("Leave", "أجازة")]
        Leave,

        [EnumGuid("8441f18d-17ba-4974-9f8b-d74472f81522")]
        [EnumStringNameValue("Partial Permission", "تصريح جزئي")]
        PartialPermission,

        [EnumGuid("8441f18d-17ba-4974-9f8b-d74472f81533")]
        [EnumStringNameValue("Overtime", "وقت اضافي")]
        Overtime,
        [EnumGuid("40144a96-b6b3-4aae-bb68-3a9d27c58044")]
        [EnumStringNameValue("Leave Return", "العوده من الاجازه")]
        LeaveReturn,
        [EnumGuid("10efc918-ef1f-409a-a0b3-ee5d35932997")]
        [EnumStringNameValue("FullDay Permision", "تصريح يوم كامل")]
        FullDayPermision,

        [EnumGuid("8641f18d-17ba-4974-9f8b-d74472f81543")]
        [EnumStringNameValue("Forget Sign", "نسيان بصمه")]
        ForgetSign,
        [EnumGuid("8641f18d-17ba-4974-9f8b-d74472f81544")]
        [EnumStringNameValue("Allowances", "اعفاء")]
        Allowances
    }


    public enum RequestFilter
    {
        [EnumGuid("db79584c-f807-481a-8a89-a8a1904bc1fc")]
        AllRequests,
        [EnumGuid("db79584c-f204-481a-8a89-a8a1904bc1fc")]
        DelegatedRequests,
        [EnumGuid("db79584c-f209-481a-8a89-a8a1904bc1fc")]
        NativeRequests,
    }

    public enum WorkflowModulesEnum
    {
        [EnumGuid("db79584c-f808-481a-8a89-a8a1904bc1fc")]
        Leave,
        [EnumGuid("db79584c-f201-481a-8a89-a8a1904bc1fc")]
        PartialPermission,
        [EnumGuid("db79584c-f203-481a-8a89-a8a1904bc1fc")]
        Overtime,
        [EnumGuid("db79584c-f908-481a-8a89-a8a1904bc1fc")]
        LeaveReturn,
        [EnumGuid("db79584c-f202-481a-8a89-a8a1904bc1fc")]
        FullDayPermision
    }
    public enum ActualWorkingDayTypeEnum
    {
        [EnumGuid("40144a96-b6b3-4aae-bb68-3a9d27c58011")]
        [EnumStringNameValue("Leave", "أجازة")]
        Leave,
        [EnumGuid("10efc918-ef1f-409a-a0b3-ee5d35932997")]
        [EnumStringNameValue("FullDay Permision", "تصريح يوم كامل")]
        FullDayPermision
    }
    public enum MangerCodeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Direct manager", "مدير مباشر")]
        DirectManager,

        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Next manager", "المدير التالي")]
        NextManager,

        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Next manager1", "المدير التالي1")]
        NextManager1,

        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Next manager2", "المدير التالي2")]
        NextManager2,
    }

    public enum PreviousBalanceTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Manual", "يدوي")]
        Manual,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Sheet", "ملف")]
        Sheet,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Calculated", "حسابية")]
        Calculated,
    }
    public enum LockYearTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Leaves", "أجازات")]
        Leaves,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Permissions", "إستئذانات")]
        Permissions,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Employee Allowances", "اعفاءات / سماحيات الموظفين")]
        EmployeeAllowances,
        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Emergency Allowances", "الاعفاءات الطارئة")]
        EmergencyAllowances,
        [EnumGuid("50000000-5000-5000-5000-500000000000")]
        [EnumStringNameValue("Employee FullDayPermission", "تصريح يوم كامل")]
        EmployeeFullDayPermission
    }
    public enum ActionTypeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Opened", "مفتوح")]
        Open,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Closed", "مغلق")]
        Closed,
    }

    public enum DutyAttendanceCommitmentEnum
    {
        [EnumGuid("36830c2c-6f22-4d2c-8a7e-a3581af388ea")]
        [EnumStringNameValue("Very highly committed", "ملتزم بدرجة عالية جدا")]
        Veryhighlycommitted,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b2")]
        [EnumStringNameValue("highly committed", "ملتزم بدرجة عالية")]
        Highlycommitted,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b3")]
        [EnumStringNameValue("Well committed", "ملتزم بدرجة جيدة")]
        Wellcommitted,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b4")]
        [EnumStringNameValue("Acceptable commitment", "ملتزم بدرجة مقبولة")]
        Acceptablecommitment,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b5")]
        [EnumStringNameValue("Somewhat committed", "ملتزم لحد ما")]
        Somewhatcommitted,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b6")]
        [EnumStringNameValue("His commitment is limited", "التزامه محدود")]
        Hiscommitmentlimited,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b7")]
        [EnumStringNameValue("His commitment is very limited", "التزامه محدود جدا")]
        Hiscommitmentverylimited,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b8")]
        [EnumStringNameValue("His commitment is weak", "التزامه ضعيف")]
        Hiscommitmentweak,
        [EnumGuid("79362e32-905a-4c0d-a24e-ff6e051275b9")]
        [EnumStringNameValue("His commitment is very weak", "التزامه ضعيف جدا")]
        Hiscommitmentveryweak,
        [EnumGuid("79362e42-905a-4c0d-a24e-ff6e051275b2")]
        [EnumStringNameValue("Not always committed", "غير ملتزم دائما")]
        Notalwayscommitted
    }

    public enum NotificationUrlEnum
    {
        [EnumStringNameValue("/main/my-request/permission-tabs/permission-tabs/permission-request-details/", "/home/myRequests/part-day/permission-request-details/")]
        RequesterMyPermissionUrl = 1,
        [EnumStringNameValue("/main/my-request/leave-tabs/leave-tabs/leave-request-details/", "/home/myRequests/request-leave/leave-request-details/")]
        RequesterMyLeaveUrl = 2,
        [EnumStringNameValue("/main/my-request/return-leave-tabs/return-leave-tabs/return-leave-details/", "/home/myRequests/return-from-leave/return-leave-request-details/")]
        RequesterMyLeaveReturnUrl = 3,
        [EnumStringNameValue("/main/my-request/overtime-tabs/overtime-tabs/overtime-request-details/", "/home/myRequests/over-time/overtime-request-details/")]
        RequesterMyOverTimeUrl = 4,
        [EnumStringNameValue("/main/my-request/full-day-permission-tabs/full-day-permission-tabs/full-day-request-details/", "/home/myRequests/full-day/full-day-request-details/")]
        RequesterMyFullDayPermissionUrl = 5,
        [EnumStringNameValue("/main/request/permission-tabs/permission-tabs/approve-permission-request/", "/home/requests/manager-part-day/approve-permission-request/")]
        ApproverPermissionUrl = 6,
        [EnumStringNameValue("/main/request/leave-tabs/leave-tabs/approve-leave-request/", "/home/requests/manager-leave/approve-leave-request/")]
        ApproverLeaveUrl = 7,
        [EnumStringNameValue("/main/request/return-leave-tabs/return-leave-tabs/approve-return-leave-request/", "/home/requests/manager-return-leave/approve-return-leave-request/")]
        ApproverLeaveReturnUrl = 8,
        [EnumStringNameValue("/main/request/overtime-tabs/overtime-tabs/approve-overtime-request/", "/home/requests/manager-over-time/approve-overtime-request/")]
        ApproverOverTimeUrl = 9,
        [EnumStringNameValue("/main/request/full-day-permission-tabs/full-day-permission-tabs/approve-full-day-permission-request/", "/home/requests/manager-full-day/approve-full-day-permission-request/")]
        ApproverFullDayPermissionUrl = 10,
        [EnumStringNameValue("/main/my-request/forget-sign-tabs/forget-sign-tabs/forget-sign-request-details/", "/home/myRequests/forget-sign/forget-sign-request-details/")]
        RequesterMyForgetSignUrl = 11,
        [EnumStringNameValue("/main/request/forget-sign-tabs/forget-sign-tabs/approve-forget-sign-request/", "/home/requests/manager-forget-sign/approve-forget-sign-request/")]
        ApproverForgetSignUrl = 12,
        [EnumStringNameValue("/main/request/allowance-tabs/allowance-tabs/approve-allowance/", "/home/requests/manager-allowance/approve-allowance-request/")]
        ApproverAllowanceUrl = 13,
        [EnumStringNameValue("/main/my-request/allowance-tabs/allowance-tabs/allowance-request-details/", "/home/myRequests/allowance/allowance-request-details/")]
        RequestMyAllowanceUrl = 14,
    }
    public enum HostApiDataEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("HOST_API", "HOST_API")]
        HOST_API,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Notification_API", "Notification_API")]
        Notification_API,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Logs_APIHub", "Logs_APIHub")]
        Logs_APIHub,
        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Logout_APIHub", "Logout_APIHub")]
        Logout_APIHub
    }
    public enum TotalGradeEnum
    {
        [EnumGuid("10000000-1000-1000-1000-100000000000")]
        [EnumStringNameValue("Poor", "ضعيف")]
        Poor,
        [EnumGuid("20000000-2000-2000-2000-200000000000")]
        [EnumStringNameValue("Good", "جيد")]
        Good,
        [EnumGuid("30000000-3000-3000-3000-300000000000")]
        [EnumStringNameValue("Very Good", "جيد جداً")]
        VeryGood,
        [EnumGuid("40000000-4000-4000-4000-400000000000")]
        [EnumStringNameValue("Excellent", "امتياز")]
        Excellent,
        [EnumGuid("50000000-5000-5000-5000-500000000000")]
        [EnumStringNameValue("تقييم اعتباري", "تقييم اعتباري")]
        Rating
    }


    public enum MobileModuleEnum
    {
        [EnumGuid("db79524c-f208-481a-8a89-a8a1904bc1fc")]
        MyInquiry,
        [EnumGuid("db79524c-f308-481a-8a89-a8a1904bc1fc")]
        MyAdministration,
        [EnumGuid("db79524c-f408-481a-8a89-a8a1904bc1fc")]
        Requests,
        [EnumGuid("db79524c-f508-481a-8a89-a8a1904bc1fc")]
        Sign,
        [EnumGuid("db89524c-f508-481a-8a89-a8a1904bc2fc")]
        Face
    }

    public enum NotificationTypeEnum
    {
        [EnumStringNameValue("Workflow", "الدورة المستندية")]
        Workflow = 1,
        [EnumStringNameValue("News", "اخبار")]
        News = 2,
        [EnumStringNameValue("HR", "الموارد البشرية")]
        HR = 3,
    }


    //ReportAuditUserAction
    public enum ReportAuditUserActionEnum
    {
        [EnumGuid("00000000-0000-0000-0000-000000000001")]
        [EnumStringNameValue("Search In Employee Logs", "بحث بتوقيعات الموظفين")]
        SearchInEmployeeLogs = 1,
        [EnumGuid("00000000-0000-0000-0000-000000000002")]
        [EnumStringNameValue("Search In Absence Employees", "بحث بتوقيعات الغائبين")]
        SearchInAbsenceEmployees = 2,
        [EnumGuid("00000000-0000-0000-0000-000000000003")]
        [EnumStringNameValue("Search In Unknown Employee Logs", "بحث بتوقيعات الموظفين غير المعرفين")]
        SearchInUnknownEmployeeLogs = 3,
        [EnumGuid("00000000-0000-0000-0000-000000000004")]
        [EnumStringNameValue("Attendance Report", "تقرير الحضور والانصراف")]
        AttendanceReport = 4,
        [EnumGuid("00000000-0000-0000-0000-000000000005")]
        [EnumStringNameValue("Leaves Report", "تقرير اجازات الموظفين")]
        LeavesReport = 5,
        [EnumGuid("00000000-0000-0000-0000-000000000006")]
        [EnumStringNameValue("Permission Report", "تقرير التصاريح الجزئية")]
        PermissionReport = 6,
        [EnumGuid("00000000-0000-0000-0000-000000000007")]
        [EnumStringNameValue("Employee Duties Report", "تقرير دوامات الموظفين")]
        EmployeeDutiesReport = 7,
        [EnumGuid("00000000-0000-0000-0000-000000000008")]
        [EnumStringNameValue("Full Day Permission Report", "تقرير تصريحات يوم كامل")]
        FullDayPermissionReport = 8,
        [EnumGuid("00000000-0000-0000-0000-000000000009")]
        [EnumStringNameValue("OverTime Report", "تقرير الوقت الاضافي")]
        OverTimeReport = 9,

        [EnumGuid("00000000-0000-0000-0000-000000000010")]
        [EnumStringNameValue("Permission Balance Report", "تقرير رصيد التصاريح الجزئية")]
        PermissionBalanceReport = 10,


        [EnumGuid("00000000-0000-0000-0000-000000000011")]
        [EnumStringNameValue("Leave Balance Report", "تقرير رصيد اجازات الموظفين")]
        LeaveBalanceReport = 11,
        [EnumGuid("00000000-0000-0000-0000-000000000012")]
        [EnumStringNameValue("Calculate OverTime Report", "تقرير حساب الوقت الاضافي ")]
        CalculateOverTimeReport = 12,
        [EnumGuid("00000000-0000-0000-0000-000000000013")]
        [EnumStringNameValue("Deductions Report", "تقرير الخصومات")]
        DeductionsReport = 13,
        [EnumGuid("00000000-0000-0000-0000-000000000014")]
        [EnumStringNameValue("Employee On/Out Service Report", "تقرير الموظفين")]
        EmployeeOnOutServiceReport = 14,
        [EnumGuid("00000000-0000-0000-0000-000000000015")]
        [EnumStringNameValue("Admin Manger Report", "تقرير مديري الادارات")]
        AdminMangerReport = 15,
        [EnumGuid("00000000-0000-0000-0000-000000000016")]
        [EnumStringNameValue("Allowances Report", "تقرير اعفاءات/سماحيات")]
        AllowancesReport = 16,
        [EnumGuid("00000000-0000-0000-0000-000000000017")]
        [EnumStringNameValue("Search In User Role Authority Report", "البحث في تقرير صلاحيات المستخدمين")]
        SearchInUserRoleAuthorityReport = 17,
        [EnumGuid("00000000-0000-0000-0000-000000000018")]
        [EnumStringNameValue("Employee Without Finger Print Report", "تقرير المعـفـيـيـن من البصمـة")]
        EmployeeWithoutFingerPrintReport = 18,
        [EnumGuid("00000000-0000-0000-0000-000000000019")]
        [EnumStringNameValue("Approve Overtime Report", "تقرير اعتماد الوقت الاضافى")]
        ApproveOvertimeReport = 19,
        [EnumGuid("00000000-0000-0000-0000-000000000020")]
        [EnumStringNameValue("Employees Evaluation Report", "تقرير التقييم السنوي")]
        EmployeesEvaluationReport = 20,


        [EnumGuid("00000000-0000-0000-0000-000000000021")]
        [EnumStringNameValue("Actual Working Days Report", "تقرير أيام العمل الفعليه")]
        ActualWorkingDaysReport = 21,
        [EnumGuid("00000000-0000-0000-0000-000000000022")]
        [EnumStringNameValue("Employee Logs Report", "تقرير حركات الموظفين اليوميه ")]
        EmployeeLogsReport = 22,
        [EnumGuid("00000000-0000-0000-0000-000000000023")]
        [EnumStringNameValue("UnKnown User Report", "تقرير حركات الموظفين غير المعروفه")]
        UnKnownUserReport = 23,
        [EnumGuid("00000000-0000-0000-0000-000000000024")]
        [EnumStringNameValue("Convert UnKnown User Report", "تقرير الموظفين المحولين من الغير معروفه")]
        ConvertUnKnownUserReport = 24,
        [EnumGuid("00000000-0000-0000-0000-000000000025")]
        [EnumStringNameValue("Employees Penalties Report", "تقرير عـقـوبــات المـوظـفـيــــن")]
        EmployeesPenaltiesReport = 25,
        [EnumGuid("00000000-0000-0000-0000-000000000026")]
        [EnumStringNameValue("Monthly Specia Finall Report", "مزاولة الاختصاصيين زاك")]
        MonthlySpeciaFinallReport = 26,
        [EnumGuid("00000000-0000-0000-0000-000000000027")]
        [EnumStringNameValue("Cost Paeet Report", "تقرير التكاليف")]
        CostPaeetReport = 27,
        [EnumGuid("00000000-0000-0000-0000-000000000028")]
        [EnumStringNameValue("Flexible Attendance Report", "تقرير الحضور والانصراف المرن")]
        FlexibleAttendanceReport = 28,
        [EnumGuid("00000000-0000-0000-0000-000000000029")]
        [EnumStringNameValue("Employee Status Report", "تقرير حالات الموظفين")]
        EmployeeStatusReport = 29,

        [EnumGuid("00000000-0000-0000-0000-000000000030")]
        [EnumStringNameValue("Employee Duty Shift Summary Report", "تقرير ملخص دوام موظفين النوبات")]
        EmployeeDutyShiftSummaryReport = 30,


        [EnumGuid("00000000-0000-0000-0000-000000000031")]
        [EnumStringNameValue("LateIn Memo", "إشعار حضور متأخر")]
        LateInMemo = 31,
        [EnumGuid("00000000-0000-0000-0000-000000000032")]
        [EnumStringNameValue("Early Out Memo", "إشعار انصراف مبكر")]
        EarlyOutMemo = 32,
        [EnumGuid("00000000-0000-0000-0000-000000000033")]
        [EnumStringNameValue("Absences Memo", "إشعار غيابات الموظفين")]
        AbsencesMemo = 33,
        [EnumGuid("00000000-0000-0000-0000-000000000034")]
        [EnumStringNameValue("Deduction Memo", "إشعار خصم")]
        DeductionMemo = 34,
        [EnumGuid("00000000-0000-0000-0000-000000000035")]
        [EnumStringNameValue("Deduction Financiall Final Memo", " إشعار الخصم الموجه للإدارةالمالية")]
        DeductionFinanciallFinalMemo = 35,
        [EnumGuid("00000000-0000-0000-0000-000000000036")]
        [EnumStringNameValue("Deduction Memo", " إشعار تأخير")]
        Deduction = 36,
        [EnumGuid("00000000-0000-0000-0000-000000000037")]
        [EnumStringNameValue("No Sign Out Memo", "إشعار عدم توقيع انصراف")]
        NoSignOutMemo = 37,
        [EnumGuid("00000000-0000-0000-0000-000000000038")]
        [EnumStringNameValue("No Sign In Memo", "إشعار عدم توقيع حضور")]
        NoSignInMemo = 38,
        [EnumGuid("00000000-0000-0000-0000-000000000039")]
        [EnumStringNameValue("Deduction Day Or More Than Day Memo", "إشعار تأخير يوم عمل كامل وأكثر")]
        DeductionDayOrMoreThanDayMemo = 39,
        [EnumGuid("00000000-0000-0000-0000-000000000040")]
        [EnumStringNameValue("Deduction Legai Memo", "التحويل للتحقيق و الموجه للإدارة القانونية")]
        DeductionLegaiMemo = 40,


        [EnumGuid("00000000-0000-0000-0000-000000000041")]
        [EnumStringNameValue("Annual Appraisal Memo", "إشعار التقييم السنوى")]
        AnnualAppraisalMemo = 41,
        [EnumGuid("00000000-0000-0000-0000-000000000042")]
        [EnumStringNameValue("No Sign In Kuna Memo", "إشعار عدم توقيع حضور Kuna")]
        NoSignInKunaMemo = 42,
        [EnumGuid("00000000-0000-0000-0000-000000000043")]
        [EnumStringNameValue("No Sign Out Kuna Memo", "إشعار عدم توقيع انصراف Kuna")]
        NoSignOutKunaMemo = 43,
        [EnumGuid("00000000-0000-0000-0000-000000000044")]
        [EnumStringNameValue("Administrative Decisions Model", " نموذج قرار الادارة العليا")]
        AdministrativeDecisionsModel = 44,
        [EnumGuid("00000000-0000-0000-0000-000000000045")]
        [EnumStringNameValue("Actual Working Days Per Month Report", "تقرير ايام العمل الفعليه في الشهر")]
        ActualWorkingDaysPerMonthReport = 45,


    }
    // Enums For Expression generator
    public enum OperationExpressionEnum
    {
        EqualTo,
        NotEqualTo,
    }
    public enum SelectorsEnum
    {
        And = 1,
        Or = 2,
        NotNullAnd = 3,
        NotNullOr = 4
    }
    // Helper for Enum Guid
    class EnumGuid : Attribute
    {
        public Guid Guid;

        public EnumGuid(string guid)
        {
            Guid = new Guid(guid);
        }
    }
    class EnumStringNotificationValue
    {
        public string OldUrl;
        public string NewUrl;
        public EnumStringNotificationValue(string oldUrl, string newUrl)
        {
            this.OldUrl = oldUrl;
            this.NewUrl = newUrl;
        }
    }
    class EnumStringNameValue : Attribute
    {
        public string NameFl;
        public string NameSl;
        public bool CanShow;
        public bool CanShowMobile;
        public string Code;

        public EnumStringNameValue(string nameFl, string nameSl, string code = null)
        {
            this.NameFl = nameFl;
            this.NameSl = nameSl;
            this.Code = code;
        }
        public EnumStringNameValue(string nameFl, string nameSl, bool canShow, bool canShowMobile)
        {
            this.NameFl = nameFl;
            this.NameSl = nameSl;
            this.CanShow = canShow;
            this.CanShowMobile = canShowMobile;
        }
    }
    public static class EnumExtensionsClass
    {
        public static Guid GetEnumGuid(this Enum e)
        {
            Type type = e.GetType();

            MemberInfo[] memInfo = type.GetMember(e.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumGuid), false);
                if (attrs != null && attrs.Length > 0)
                    return ((EnumGuid)attrs[0]).Guid;
            }

            throw new ArgumentException("Enum " + e.ToString() + " has no EnumGuid defined!");
        }
        public static List<string> GetName(this Enum e, bool isMigration)
        {
            var type = e.GetType();

            var memInfo = type.GetMember(e.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumStringNameValue), false);
                if (attrs != null && attrs.Length > 0)
                {
                    var attributes = (EnumStringNameValue)attrs[0];
                    var list = new List<string>
                    {
                       attributes.NameFl,
                       attributes.NameSl,
                    };
                    if (attributes?.CanShow != null) list.Add(attributes?.CanShow.ToString());
                    if (attributes?.CanShowMobile != null) list.Add(attributes?.CanShow.ToString());

                    return list;
                }
            }

            throw new ArgumentException("Name " + e.ToString() + " has no Name defined!");
        }

        //public static List<string> GetNotificationName(this Enum e)
        //{
        //    var type = e.GetType();

        //    var memInfo = type.GetMember(e.ToString());

        //    if (memInfo != null && memInfo.Length > 0)
        //    {
        //        object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumStringNotificationValue), false);
        //        if (attrs != null && attrs.Length > 0)
        //        {
        //            var attributes = (EnumStringNotificationValue)attrs[0];
        //            var list = new List<string>
        //            {
        //               attributes.OldUrl,
        //               attributes.NewUrl
        //            };
        //            return list;
        //        }
        //    }

        //    throw new ArgumentException("Name " + e.ToString() + " has no Name defined!");
        //}
        public static List<string> GetName(this Enum e)
        {
            var type = e.GetType();
            var sysLang = Helper.ChangeProperty();
            var memInfo = type.GetMember(e.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumStringNameValue), false);
                if (attrs != null && attrs.Length > 0)
                {
                    var attributes = (EnumStringNameValue)attrs[0];
                    var list = new List<string>
                    {
                         sysLang == (int)Helper.ChangePropertyEnum.ArEn ? attributes.NameSl : attributes.NameFl,
                         sysLang == (int)Helper.ChangePropertyEnum.Ar ||sysLang ==  (int)Helper.ChangePropertyEnum.En || sysLang == (int)Helper.ChangePropertyEnum.ArEn ? attributes.NameFl : attributes.NameSl
                    };
                    if (attributes?.CanShow != null) list.Add(attributes?.CanShow.ToString());
                    if (attributes?.CanShowMobile != null) list.Add(attributes?.CanShow.ToString());

                    return list;
                }
            }

            throw new ArgumentException("Name " + e.ToString() + " has no Name defined!");
        }

        public static List<string> GetNameWithoutMigrate(this Enum e)
        {
            var type = e.GetType();
            var sysLang = Helper.ChangeProperty();
            var memInfo = type.GetMember(e.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumStringNameValue), false);
                if (attrs != null && attrs.Length > 0)
                {
                    var attributes = (EnumStringNameValue)attrs[0];
                    var list = new List<string>
                    {
                        attributes.NameFl, attributes.NameSl
                    };
                    return list;
                }
            }

            throw new ArgumentException("Name " + e.ToString() + " has no Name defined!");
        }

        public static T GetEnum<T>(this Guid guid) where T : struct, IConvertible
        {
            var enums = Enum.GetValues(typeof(T));
            T result = new T();
            foreach (var item in enums)
            {
                if (((Enum)item).GetEnumGuid() == guid) result = (T)item;
            }
            return result;
        }

        public static EnumResult GetEnumName(this Enum e)
        {
            var type = e.GetType();

            var memInfo = type.GetMember(e.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(EnumStringNameValue), false);
                if (attrs.Length > 0)
                {
                    var attrbutes = (EnumStringNameValue)attrs[0];
                    return new EnumResult
                    {
                        Id = Convert.ToInt32(e),
                        NameEn = attrbutes.NameFl,
                        NameAr = attrbutes.NameSl,
                        Code = attrbutes.Code
                    };
                }
            }

            throw new ArgumentException("Name " + e.ToString() + " has no Name defined!");
        }

    }
    public class EnumResult
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
    }
}