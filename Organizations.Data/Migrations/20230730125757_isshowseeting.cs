using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class isshowseeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowActualWorkingDay",
                table: "SettingActualWorkings");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELe5K8zUwN87FX2W4Wf/BdVcLkKNOL43GIEY9EmueSpwJgyMyA7Y6hJibPdS0po/8Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 16, 10, 41, 20, 713, DateTimeKind.Local).AddTicks(4791));
        }
    }
}
