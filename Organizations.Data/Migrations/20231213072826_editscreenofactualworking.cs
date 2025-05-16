using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class editscreenofactualworking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c310ef"), false, "menu15", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "notifications_active", false, false, null, null, (short)30, null, "/main/lookups/general-setting-parent-regulations" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEKaHsFyLKIH7WGezp1GQG0mgZ0R2Vqfn0MuPSXAkCNYRCSecNYprAvQgwatcts2rRg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 9, 28, 22, 740, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)1, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c310ef") });

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)2, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c310ef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c310ef"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd88"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)22, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc") });

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("9389daad-0c9f-47ba-825b-bc37d119bd89"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)23, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEII42SRq8dkszAFZbHm5X17NnGrrfnbfevgwUwBnoQArMzF/cGNJh5/AmjQmZBTqDw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 14, 47, 24, 449, DateTimeKind.Local).AddTicks(1604));
        }
    }
}
