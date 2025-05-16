using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _setting_OneUserDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseOneDeviceForUserInquiry",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENBpmQe9G8MQtCEfByKJiunYJDW9KJJYOs+K1yM7ASLvydDA1s02WCgz0siLbGFDgQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 6, 13, 12, 34, 39, 122, DateTimeKind.Local).AddTicks(8075));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseOneDeviceForUserInquiry",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDm6sUk7pSHvkr+xKTeILHGZOnWUX5IWBk3vGPsKmp2TvUBnRNxKAtUTMfOROQTQag==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 30, 13, 56, 48, 75, DateTimeKind.Local).AddTicks(6867));
        }
    }
}
