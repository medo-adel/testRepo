using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class paaetreportmodule1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("3bde3840-3b65-4854-a229-ae5d7d622230"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-33a1-48ce-bde1-103bdde75432") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGfBwL0242NsIaXdQ9i4vhCVVPJm7udi9JTR7vTm3uOgAR2UzPCDEf0ZQ4kCr0rhHw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 23, 16, 9, 20, 551, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab6-5a41-491c-843f-e4522550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db22584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3b65-4854-a229-ae5d7d622230"));

            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d96baab6-5a41-491c-843f-e4522550d6a8"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEF+dBRpy5DuTLC6b7vt8MEzNCtuCKvs2pds1fhIL8yO/ReREAKtx0mA9seuWuv+lkg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 23, 16, 4, 48, 918, DateTimeKind.Local).AddTicks(8685));
        }
    }
}
