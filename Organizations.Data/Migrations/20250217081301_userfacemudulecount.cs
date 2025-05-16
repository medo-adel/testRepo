using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class userfacemudulecount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfUsersHaveFaceModule",
                table: "OrganizationLicenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUsersHaveFaceModule",
                table: "OrganizationLicenseRequests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM764I6IE30IWjMQ5380RrFlGl/1HxEx+G8HJ4xjYt4pO4Uru8mekRDF/aBIIR7m9Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 10, 12, 57, 859, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 17, 10, 12, 57, 879, DateTimeKind.Local).AddTicks(7401));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfUsersHaveFaceModule",
                table: "OrganizationLicenses");

            migrationBuilder.DropColumn(
                name: "NumberOfUsersHaveFaceModule",
                table: "OrganizationLicenseRequests");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAECXtmsEgssHG5Xu4JuHwpujcC0VQ3ZcDIBaYDDOs4Bo53HTX5DqIoG9cEc3cup3Opw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 17, 29, 10, 520, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 16, 17, 29, 10, 538, DateTimeKind.Local).AddTicks(7300));
        }
    }
}
