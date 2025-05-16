using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class ThirdSignInOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsThirdSign",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PermisionTimeForThirdSign",
                table: "OrganizationSetting",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TimeSendNotification",
                table: "OrganizationSetting",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDcmCDvxeM+3xi+Jft1kQnK9Vgm/2eoLcnDTzWopfSzngz/+sUAUudg7SKh5U1dV9A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 1, 10, 26, 54, 544, DateTimeKind.Local).AddTicks(6113));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsThirdSign",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "PermisionTimeForThirdSign",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "TimeSendNotification",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEG/Y3nax8SUWIagidExNz/67yl3oPP+pvaIaAnCMYT9ol2H3wxVKRwDfQtnhbpVbUg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 15, 57, 15, 378, DateTimeKind.Local).AddTicks(5280));
        }
    }
}
