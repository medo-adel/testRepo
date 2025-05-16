using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class EmployeeAttendanceEditInDbComponentMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe555"), true, "EmployeeAttendanceEditInDbComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)7, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/employee-attendance-edit-in-db" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEIUnHx/GZE0KcYvAF9PesoCscfRYLphCHPvSd5AeRAju2Q7vOxpyt9mD1v0vnn5oow==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 16, 50, 55, 670, DateTimeKind.Local).AddTicks(3435));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe555"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENBpmQe9G8MQtCEfByKJiunYJDW9KJJYOs+K1yM7ASLvydDA1s02WCgz0siLbGFDgQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 6, 13, 12, 34, 39, 122, DateTimeKind.Local).AddTicks(8075));
        }
    }
}
