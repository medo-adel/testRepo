using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AumMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[] { new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Aum Mobile Module", "Aum Mobile Module", null });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("18c02172-1ea6-4e4e-a6e2-ec0ce5c310ef"), true, "menu8", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_device_information", false, false, null, null, (short)30, null, null });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH3C4npPi9ntwBUyeI52q5MTctPowFmXtzHmHfN7friExSlCJaXfKjmAWxS50wPctQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 11, 50, 52, 358, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "PackageNameFl", "PackageNameSl" },
                values: new object[] { new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658"), new Guid("1e99618b-6294-4786-8b00-2b8e294c66fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Aum Mobile Package", "Aum Mobile Package" });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("9389daad-0c9f-47ba-825c-bc37d119bd88"), true, "mobileUsers", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group", false, false, null, null, (short)1, new Guid("18c02172-1ea6-4e4e-a6e2-ec0ce5c310ef"), "/main/mobile/mobile-users" },
                    { new Guid("9389daad-0c9f-47ba-825a-bc37d119bd89"), true, "mobileWorkCenters", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "domain", false, false, null, null, (short)2, new Guid("18c02172-1ea6-4e4e-a6e2-ec0ce5c310ef"), "/main/mobile/work-centers" },
                    { new Guid("9389daad-0c9f-47ba-825d-bc37d119bd89"), true, "mobileLocationRange", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "location_on", false, false, null, null, (short)3, new Guid("18c02172-1ea6-4e4e-a6e2-ec0ce5c310ef"), "/main/mobile/location-range" }
                });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658") });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("3bde3840-3c80-4854-a229-ae5d7d622831"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("9389daad-0c9f-47ba-825c-bc37d119bd88") });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("9389daad-9c9f-47ba-825a-bc37d119bd89"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("9389daad-0c9f-47ba-825a-bc37d119bd89") });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("9989daad-0c9f-47ba-825d-bc37d119bd89"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("9389daad-0c9f-47ba-825d-bc37d119bd89") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3c80-4854-a229-ae5d7d622831"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-9c9f-47ba-825a-bc37d119bd89"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("9989daad-0c9f-47ba-825d-bc37d119bd89"));

            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825a-bc37d119bd89"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825c-bc37d119bd88"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825d-bc37d119bd89"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("18c02172-1ea6-4e4e-a6e2-ec0ce5c310ef"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEC5sDqZiPKi5odTJaxbhId8R8JSAhS9/H9mrKopo6VfzDBERK+BphFh7SrllGfa7uA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 10, 29, 12, 784, DateTimeKind.Local).AddTicks(7866));
        }
    }
}
