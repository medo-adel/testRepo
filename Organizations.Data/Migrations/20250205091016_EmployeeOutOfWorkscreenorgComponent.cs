using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class EmployeeOutOfWorkscreenorgComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateExecutedThirdSign",
            //    table: "OrganizationSetting",
            //    type: "datetime2",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsCalulteThirdSignFromExpectitedTime",
            //    table: "OrganizationSetting",
            //    type: "bit",
            //    nullable: true);

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe677"), true, "EmployeeOutOfWorkComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)9, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/employee-out-of-work" }
                });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKWwczBL/xvB6LOiGn6fNdyd7muK4CjxPVnOWeLWhHOQ1uspKCrUJBGDqCP7fUfFrw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 5, 11, 10, 13, 825, DateTimeKind.Local).AddTicks(1352));

        
            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("a5373e92-5851-42f3-a55e-1c52ea69cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe677") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e92-5851-42f3-a55e-1c52ea69cef8"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e92-5851-42f3-a55e-1c52ea69cef9"));
          

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe677"));

            //migrationBuilder.DropColumn(
            //    name: "DateExecutedThirdSign",
            //    table: "OrganizationSetting");

            //migrationBuilder.DropColumn(
            //    name: "IsCalulteThirdSignFromExpectitedTime",
            //    table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELN7P7O4F86zK+nv8+rHF8tVzq4JmnE/khPmJfU3gQFvuVQsO0WAT0dQxFKAkcLjlg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 14, 25, 25, 333, DateTimeKind.Local).AddTicks(2332));
        }
    }
}
