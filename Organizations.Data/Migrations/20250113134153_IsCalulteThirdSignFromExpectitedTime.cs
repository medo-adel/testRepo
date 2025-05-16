using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class IsCalulteThirdSignFromExpectitedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCalulteThirdSignFromExpectitedTime",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAFjFjdeUCd1YUf5816X/OY1GQ5N7FvQtraFYDicTUJlWg03d2GNlEk2OIzrYF4yUQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 15, 41, 49, 40, DateTimeKind.Local).AddTicks(6953));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCalulteThirdSignFromExpectitedTime",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAlRyTUV+kEuOC33oqu6zo9W7mP6dGOhiWqgeQSHHQWpT4oM7TxY27AiC0e4Qfjhdg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 13, 14, 18, 21, 162, DateTimeKind.Local).AddTicks(1758));
        }
    }
}
