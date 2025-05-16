using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class SendNotificationLogBeforeAfterDutyinsetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendNotificationLogBeforeAfterDuty",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGE9B2RTtaJAWcGqyYzNAW4TuehK6Xs0f9I2Qq0gVw7BSIrWKL92f/vnLpEwiIsQ4w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 27, 13, 1, 28, 599, DateTimeKind.Local).AddTicks(7824));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendNotificationLogBeforeAfterDuty",
                table: "OrganizationSetting");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEP3U2XldfG7NuCNTTvXYXh+UtDmVGwcCmonja62xZRGaPGZvp+mDx2Sp1YQHYfi74w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 11, 35, 54, 627, DateTimeKind.Local).AddTicks(7234));
        }
    }
}
