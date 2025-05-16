using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class updateinactivedirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActiveDirectoryKey",
                keyColumn: "Id",
                keyValue: new Guid("10000000-1000-1000-1000-100000000000"));

            migrationBuilder.DeleteData(
                table: "ActiveDirectoryKey",
                keyColumn: "Id",
                keyValue: new Guid("20000000-2000-2000-2000-200000000000"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("32aab175-d4fd-6408-8e8a-590dabaa6b14"),
                column: "IsReport",
                value: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEpxxDh8FNusovUaY0GgTu0cblnRRXvTadquFpjhbvthI0WSZzZpTHA0filVHe9rug==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 16, 15, 43, 19, 293, DateTimeKind.Local).AddTicks(7565));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActiveDirectoryKey",
                columns: new[] { "Id", "ActiveDirectoryKeyNameFl", "ActiveDirectoryKeyNameSl", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("10000000-1000-1000-1000-100000000000"), "Attribute1", "Attribute1", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { new Guid("20000000-2000-2000-2000-200000000000"), "Attribute2", "Attribute2", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("32aab175-d4fd-6408-8e8a-590dabaa6b14"),
                column: "IsReport",
                value: false);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEB2cYdWsLYY68lR73FJ4/fW2LIRCRluIrL52jPXA5qfLTtEMyAPvLbr4FtDsikrHsg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 10, 30, 10, 17, 46, 394, DateTimeKind.Local).AddTicks(2426));
        }
    }
}
