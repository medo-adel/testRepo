using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _Update_Seed_aum1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAWsRojMsEJuTHKRisyzFRZwoxAasyOrAo7SJOlASwIbw6fnvnzwY5uSD+2uhP+xtQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 11, 38, 21, 777, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d28baab4-5a25-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("ac1dc6d4-b2c6-4adb-a3a8-dfd896757658") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d28baab4-5a25-491c-843f-e4593550d6a8"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGwl7xqcukFUK299IpeYBdgW4Qdt/QLx7EupL4bE7pKjseuP2tLypCr12alFFFjmKQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 11, 27, 38, 964, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db80524c-f508-491a-1a79-a9a9914bc1fc"), new Guid("ac1dc6d4-b2c6-4adb-a3a8-dfd896757658") });
        }
    }
}
