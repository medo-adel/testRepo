using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class LogTypeMobileIdInSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LogTypeMobileId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEFRtdcW5HP/7FCoxS6St1W6NKiwfyM2hLbG5gaesD7rR+WV2zq2QjbdqSp9fULRYiA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 3, 14, 10, 18, 422, DateTimeKind.Local).AddTicks(8863));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogTypeMobileId",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPtjnGH9v2Q+b3uOTSbpcaH8lbAa8sTsqp/Hoh8BUvZezGIYdkT+OqoLJEXYJtVHMA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 23, 13, 26, 15, 875, DateTimeKind.Local).AddTicks(3231));
        }
    }
}
