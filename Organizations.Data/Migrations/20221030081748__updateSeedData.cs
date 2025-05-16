using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _updateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "AQAAAAEAACcQAAAAECLOPZTc4gbeWqQ468Vrt8Tm+/CE2HE4nPenHXGxpNH5y+HRWWa9FBqQMatXcV4yJA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 10, 20, 13, 19, 56, 478, DateTimeKind.Local).AddTicks(994));
        }
    }
}
