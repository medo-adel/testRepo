using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class EditModelScreen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-5891-42f4-a44e-1c41ea59cef6"),
                column: "ModuleId",
                value: new Guid("db79584c-f608-481a-8a89-a8a1904bc1fc"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENR+ZZRjgBKm+xfPqR8cFTZ5t6boVzgNrgCxPqK4U288tUJLQRViPcnarBdBmmj7uA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 11, 27, 20, 141, DateTimeKind.Local).AddTicks(5266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-5891-42f4-a44e-1c41ea59cef6"),
                column: "ModuleId",
                value: new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAECR/+55etzQ5M+wUG4fLZc+0neKZ9Jifszvmhm7JVdSZzEHFG4ZjkhBBr/sp2C8JBw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 12, 13, 48, 53, 575, DateTimeKind.Local).AddTicks(9907));
        }
    }
}
