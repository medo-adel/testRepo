using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _employeeattendanceflexibleduty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("146d3f84-46a1-49ce-bde1-103bdde85752"), true, "EmployeeAttendanceFlexibleDutyReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)24, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-attendance-flexible-duty-report" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBzQMhWoNGbZG8LemBKbOk+CbmvW6zhEiFT4bWL30hrz/oG9fEB58Gj84P2UOzHO3Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 11, 55, 18, 682, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("a5714e40-5892-42f3-a44e-1c41ea59cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-46a1-49ce-bde1-103bdde85752") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5714e40-5892-42f3-a44e-1c41ea59cef9"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85752"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGYOgpjafwWmphR75WpR43UcwEVz8nysRhwkMCYcV49Oh0Ts7Zj7+CA2CJCATdyDlQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 1, 11, 23, 58, 148, DateTimeKind.Local).AddTicks(9195));
        }
    }
}
