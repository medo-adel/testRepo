using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class LockYearForGroupmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("93ee3f27-6a95-46e4-b177-8aa86225d85c"), true, "LockYearForGroupsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock_open", false, false, null, null, (short)5, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/lock-year-for-groups" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJyt4PeNoBEVnUoNb+PwZoIJMlFuv+dybN+2JR+2tkhp6y8H9L/SxomZzu9W5r/ICw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 54, 55, 959, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("ba3f5f24-d71d-4eda-11b1-ceaf4ae6e84d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("93ee3f27-6a95-46e4-b177-8aa86225d85c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("ba3f5f24-d71d-4eda-11b1-ceaf4ae6e84d"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("93ee3f27-6a95-46e4-b177-8aa86225d85c"));

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
        }
    }
}
