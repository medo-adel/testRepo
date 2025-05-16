using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _Update_Seed_aum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658"));

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

            migrationBuilder.UpdateData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"),
                column: "PackageId",
                value: new Guid("ac1dc6d4-b2c6-4adb-a3a8-dfd896757658"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH3C4npPi9ntwBUyeI52q5MTctPowFmXtzHmHfN7friExSlCJaXfKjmAWxS50wPctQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 11, 50, 52, 358, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "PackageNameFl", "PackageNameSl" },
                values: new object[] { new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658"), new Guid("1e99618b-6294-4786-8b00-2b8e294c66fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Aum Mobile Package", "Aum Mobile Package" });

            migrationBuilder.UpdateData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d28baab4-5a25-491c-843f-e4593550d6a7"),
                column: "PackageId",
                value: new Guid("ac1dc6d4-b2c6-4ddb-a3a8-dfd896757658"));
        }
    }
}
