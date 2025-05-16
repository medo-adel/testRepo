using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBHa7zuvLB49RFJvowUwhOZJfZ1QIaLp5kfG+7axlm5INbhfwNgslEEBcBgvMAmRPA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 7, 14, 136, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 7, 14, 151, DateTimeKind.Local).AddTicks(3010));
        }
    }
}
