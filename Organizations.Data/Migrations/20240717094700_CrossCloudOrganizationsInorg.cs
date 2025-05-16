using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class CrossCloudOrganizationsInorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd90"), false, "CrossCloudOrganizationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)22, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/Cross-Cloud-Organizations" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH2aoMRIvKf1CiVkNVTgX/BYQR5u8LZGk2u+/89juLa0t5MaJPZXGyq4dgiPiBvVXQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 17, 12, 46, 56, 229, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("c9638ab7-a62a-4d5b-9b5f-b747dffa418d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd90") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("c9638ab7-a62a-4d5b-9b5f-b747dffa418d"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd90"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDupsNrkDmi0ayPbIKYYUjvazV1mcgZlR2Xk6LTqBbykkPIcUhYwa0lrVzLVR0816g==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 15, 12, 31, 17, 523, DateTimeKind.Local).AddTicks(7405));
        }
    }
}
