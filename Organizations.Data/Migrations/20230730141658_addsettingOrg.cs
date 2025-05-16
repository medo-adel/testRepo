using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class addsettingOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowActualWorkingDay",
                table: "SettingActualWorkings");

            migrationBuilder.AddColumn<bool>(
                name: "IsShowActualWorkingDay",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEO/jlz1Wy3VIMNLSb4o9sDovu+nU7TPlZD7bQnxIm2L5ugzYuOcCcd4PIobg4ZOiqQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 30, 17, 16, 56, 86, DateTimeKind.Local).AddTicks(854));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowActualWorkingDay",
                table: "OrganizationSetting");

            migrationBuilder.AddColumn<bool>(
                name: "IsShowActualWorkingDay",
                table: "SettingActualWorkings",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEDjMWrYHIL6+qyDXwJlH+Jkw2G38QNFlGwcUYJ3L7ARRTQKav6Jw8PjY/ZZnUUJ2Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 30, 15, 57, 53, 596, DateTimeKind.Local).AddTicks(9424));
        }
    }
}
