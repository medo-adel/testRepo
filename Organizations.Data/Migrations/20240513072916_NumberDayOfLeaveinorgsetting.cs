using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class NumberDayOfLeaveinorgsetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMangerAssignDelegate",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaveRegulationId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberDayOfLeave",
                table: "OrganizationSetting",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEC5sDqZiPKi5odTJaxbhId8R8JSAhS9/H9mrKopo6VfzDBERK+BphFh7SrllGfa7uA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 10, 29, 12, 784, DateTimeKind.Local).AddTicks(7866));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMangerAssignDelegate",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "LeaveRegulationId",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "NumberDayOfLeave",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJyt4PeNoBEVnUoNb+PwZoIJMlFuv+dybN+2JR+2tkhp6y8H9L/SxomZzu9W5r/ICw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 54, 55, 959, DateTimeKind.Local).AddTicks(6167));
        }
    }
}
