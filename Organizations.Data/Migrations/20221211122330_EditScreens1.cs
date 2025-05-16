using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class EditScreens1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3b80-4854-a229-ae5d7d622831"),
                column: "ScreenId",
                value: new Guid("146d3f84-46a1-49ce-bde1-103bdde85742"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85742"),
                columns: new[] { "ComponentName", "UrlPath" },
                values: new object[] { "OverTimePaaetReportComponent", "/main/reports/over-time-paaet-report" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM+XKtOp+nc9F7YQgza9v2POR7Bop6Y30ijchWepdvYObuQpKK+rp4rxTrLb75C6+A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 11, 14, 23, 28, 289, DateTimeKind.Local).AddTicks(1324));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3b80-4854-a229-ae5d7d622831"),
                column: "ScreenId",
                value: new Guid("e4e72d50-87d5-4eea-a2c6-f02f3cd3d3b6"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85742"),
                columns: new[] { "ComponentName", "UrlPath" },
                values: new object[] { "MonthlySpeciaFinalPaaetReportComponent", "/main/reports/monthly-specia-final-paaet-report" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEHRTTl0lOk4ckjH8kND1yMORhTzT7mjt+BQeSJAs8obQm4DCMEp3VR3MlDiATdRE/w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 11, 13, 48, 15, 709, DateTimeKind.Local).AddTicks(7349));
        }
    }
}
