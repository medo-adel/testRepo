using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class screenactualpermonth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"),
                column: "UrlPath",
                value: "/main/lookups/setting-actual-working-regulations");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"),
                column: "UrlPath",
                value: "/main/lookups/general-setting-regulations");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEII42SRq8dkszAFZbHm5X17NnGrrfnbfevgwUwBnoQArMzF/cGNJh5/AmjQmZBTqDw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 14, 47, 24, 449, DateTimeKind.Local).AddTicks(1604));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"),
                column: "UrlPath",
                value: "/main/lookups/setting-actual-working");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"),
                column: "UrlPath",
                value: "/main/lookups/general-setting");

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
        }
    }
}
