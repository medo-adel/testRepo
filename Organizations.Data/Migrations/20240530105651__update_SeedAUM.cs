using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _update_SeedAUM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825a-bc37d119bd89"),
                column: "ComponentName",
                value: "WorkCentersComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825c-bc37d119bd88"),
                column: "ComponentName",
                value: "MobileUsersComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825d-bc37d119bd89"),
                column: "ComponentName",
                value: "LocationRangeComponent");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDm6sUk7pSHvkr+xKTeILHGZOnWUX5IWBk3vGPsKmp2TvUBnRNxKAtUTMfOROQTQag==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 30, 13, 56, 48, 75, DateTimeKind.Local).AddTicks(6867));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825a-bc37d119bd89"),
                column: "ComponentName",
                value: "mobileWorkCenters");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825c-bc37d119bd88"),
                column: "ComponentName",
                value: "mobileUsers");

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825d-bc37d119bd89"),
                column: "ComponentName",
                value: "mobileLocationRange");

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
        }
    }
}
