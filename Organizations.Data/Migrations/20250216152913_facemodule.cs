using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class facemodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[] { new Guid("db89524c-f508-481a-8a89-a8a1904bc2fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Face Module", "Face Module", null });

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

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab6-5a55-491c-843f-e4593550d6a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db89524c-f508-481a-8a89-a8a1904bc2fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d96baab6-5a55-491c-843f-e4593550d6a9"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("db89524c-f508-481a-8a89-a8a1904bc2fc"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBnRgSR4JNEKFlunQEqsWxgBu9T7gSO0TNIJRgY+gYWYcwvzX3fF+K25+qE7kFzgKQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 46, 44, 54, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 46, 44, 64, DateTimeKind.Local).AddTicks(4750));
        }
    }
}
