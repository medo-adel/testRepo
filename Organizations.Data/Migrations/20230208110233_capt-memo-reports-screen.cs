using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class captmemoreportsscreen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("246d3f84-55a1-49ce-bde1-113bdde72944"), true, "CaptMarriageBonusDecisionReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)14, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/capt-marriage-bonus-decision-report" },
                    { new Guid("256d3f82-55a1-49ce-bde1-113bdde72944"), true, "CaptMotherhoodDecisionReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)15, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/capt-Motherhood-decision-report" },
                    { new Guid("256d3f91-55a1-49ce-bde1-113bdde72944"), true, "CaptJobUpgradeDecisionReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)16, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/capt-job-upgrade-decision-report" }
                });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELbpdKMQ9uT7T6R2gUch2Ylltq96KdpOyn9qD6NQs97pzgQuRxLo7YzJp8sjPMIdOw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 8, 13, 2, 30, 638, DateTimeKind.Local).AddTicks(6450));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("246d3f84-55a1-49ce-bde1-113bdde72944"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f82-55a1-49ce-bde1-113bdde72944"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a1-49ce-bde1-113bdde72944"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGYkgAxyukk7XXSgYlMCwIZc7SHroZQyRrfb3HZKgM3qOBO3ybWd0+go2mJ7vkf8Rg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 8, 10, 20, 23, 929, DateTimeKind.Local).AddTicks(4017));
        }
    }
}
