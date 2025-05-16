using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class screenactualpermonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"), false, "SettingActualWorkingComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)22, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/setting-actual-working" },
                    { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"), false, "GeneralSettingComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)23, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/general-setting" }
                });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEIWlSxNxggzRq5jM26N0XscVlfwixryFUx84xa5oCWEgqDAylvB4dV1303PkekBxeA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 14, 27, 52, 470, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("224e2621-b59d-44ae-b8c2-f0cf477b052b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88") });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("224e2621-b59d-44ae-b8c2-f0cf488b052b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("224e2621-b59d-44ae-b8c2-f0cf477b052b"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("224e2621-b59d-44ae-b8c2-f0cf488b052b"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAED47aSkEhZ/gBVOwVx5pQJOODEY7CyNHBgjUB4zaSLg5pOsYU6a9Qlaavo5VWD1YcQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 16, 25, 51, 735, DateTimeKind.Local).AddTicks(7660));
        }
    }
}
