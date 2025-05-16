using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AddFaceRegistrationFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfSecondsToCheckLiveness",
                table: "OrganizationSetting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivenessLevelOptions",
                table: "OrganizationSetting",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEP4OtXmQ9z7g8HqstdzUJfdnN8KeViOpGpKEWkCknKFh8iAtdiIFqx9bozL7CygzWw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 12, 16, 50, 53, 866, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 12, 16, 50, 53, 884, DateTimeKind.Local).AddTicks(7442));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfSecondsToCheckLiveness",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "LivenessLevelOptions",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENHLgmBtYq0nIUEzp2VGOqO9ym17w4iZj2Pg/pZO0fgojjQcBkk0ejZv3A42t5dhAA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 15, 48, 55, 330, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 15, 48, 55, 354, DateTimeKind.Local).AddTicks(4006));
        }
    }
}
