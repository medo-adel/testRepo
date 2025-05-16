using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class MaxNumberofPermissionTimesPerDaysetting3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxNumberofPermissionTimesPerDay",
                table: "OrganizationSetting",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJR6nyRafL7i+qVDjdcIoSUwzP6VAJU++/MKdtqkbheny2fhWlQCfxiZFEbjARnVaw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 9, 11, 44, 4, 740, DateTimeKind.Local).AddTicks(5757));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberofPermissionTimesPerDay",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEE+Za2La+QvC0+OKZjRphvV/zRbIuzm7DA7JZA/9W8995zSNDksYpsZICdoRv3qFHg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 9, 11, 40, 15, 911, DateTimeKind.Local).AddTicks(7289));
        }
    }
}
