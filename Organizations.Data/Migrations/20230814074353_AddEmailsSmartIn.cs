using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AddEmailsSmartIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[] { new Guid("db80524c-f508-491a-1a79-a9a1914bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mailing Ndhr Module", "Mailing Ndhr Module", null });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEMkVdiZJNTfqCpOTYeYfRz+/OBniTzj6YzCBuMCfCrcIzQNYXUsfS1EfQl7knUjs0g==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 8, 14, 10, 43, 50, 998, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab7-5a25-491c-843f-e4593560d7a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db80524c-f508-491a-1a79-a9a1914bc1fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d96baab7-5a25-491c-843f-e4593560d7a8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("db80524c-f508-491a-1a79-a9a1914bc1fc"));

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
    }
}
