using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _timSheet_report2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-5992-55f3-a99e-1c42ea60cef9"),
                column: "ModuleId",
                value: new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEP7V0fuwJ4vLucbEB9ztpJOm828vJ2farLzCwbaq1cAUP34eSgG/ix3ptlxt++hHBQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 16, 44, 25, 152, DateTimeKind.Local).AddTicks(5460));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-5992-55f3-a99e-1c42ea60cef9"),
                column: "ModuleId",
                value: new Guid("db79524c-f508-491a-1a79-a9a1904bc1fc"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJCsZrZdvDedxhyTtQ97sLdyOqTaEzDZSqa7JC4DYpFXlqLLszqiIiIFdiiJCDbQEw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 16, 29, 37, 704, DateTimeKind.Local).AddTicks(3125));
        }
    }
}
