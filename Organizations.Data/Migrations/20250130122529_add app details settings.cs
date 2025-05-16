using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class addappdetailssettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VersionNumber",
                table: "AppDetails",
                newName: "Version");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELN7P7O4F86zK+nv8+rHF8tVzq4JmnE/khPmJfU3gQFvuVQsO0WAT0dQxFKAkcLjlg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 14, 25, 25, 333, DateTimeKind.Local).AddTicks(2332));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppDetails");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "AppDetails",
                newName: "VersionNumber");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEB/UEIGtjidSllBxaHs3uvjn2c8MYBjxUz/OdZTEw93w4VaD7L50hT8/7aEO/4aotg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 13, 22, 22, 68, DateTimeKind.Local).AddTicks(8117));
        }
    }
}
