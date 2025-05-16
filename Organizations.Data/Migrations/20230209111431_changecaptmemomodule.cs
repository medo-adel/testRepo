using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class changecaptmemomodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"),
                columns: new[] { "ModuleNameFl", "ModuleNameSl" },
                values: new object[] { "CAPT Module", "CAPT Module" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEL41qlYYAwEie2IfBb4qT29wP9suQdZHT5JthuDnNkV3jL12US7kY5UAkQocEdsw+A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 13, 14, 27, 915, DateTimeKind.Local).AddTicks(2690));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"),
                columns: new[] { "ModuleNameFl", "ModuleNameSl" },
                values: new object[] { "CAPT Memos Module", "CAPT Memos Module" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAVmBw7rNWsA8qbFuzT18hr58mRGb5GulVDIQ+Nf0liG8ConSLmbzL0B7/xQdjD5SQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 8, 13, 6, 12, 670, DateTimeKind.Local).AddTicks(1833));
        }
    }
}
