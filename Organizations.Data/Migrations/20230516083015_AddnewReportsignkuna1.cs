using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AddnewReportsignkuna1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a2-49ce-bde2-113bdde72945"),
                column: "ComponentName",
                value: "NoSignInKunaReportComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a3-49ce-bde3-113bdde72946"),
                column: "ComponentName",
                value: "NoSignOutKunaReportComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOnj7nEXF5ijRB8v2MMs4IQLN+TXeSyfKBSuaV1RIKHrT+E1E29oFaqv3rALFk6iIQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 11, 30, 13, 430, DateTimeKind.Local).AddTicks(504));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a2-49ce-bde2-113bdde72945"),
                column: "ComponentName",
                value: "NosignInKunaReportComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a3-49ce-bde3-113bdde72946"),
                column: "ComponentName",
                value: "NosignOutKunaReportComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBFxuJPm6LbaN+UbaE72845JOyZ80c95nOYqagoxUiUSkpzZExIWAlNS3Z3empHkpw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 10, 22, 35, 777, DateTimeKind.Local).AddTicks(8442));
        }
    }
}
