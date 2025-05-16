using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _newitemINmenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-137b-47ca-a073-55e730b82c6d"),
                column: "OrderNumber",
                value: (short)10);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-447b-47ca-a073-72e730b82c6d"),
                column: "OrderNumber",
                value: (short)8);

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("e8a82e92-447b-47ca-a073-72e730b82c7d"), true, "HrShiftsKunaComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "person_add", false, false, null, null, (short)9, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/hrshiftkuna" });

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

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("a5333e90-5892-55f3-a99e-1c42ea58cef8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79524c-f508-491a-1a79-a9a1904bc1fc"), new Guid("e8a82e92-447b-47ca-a073-72e730b82c7d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5333e90-5892-55f3-a99e-1c42ea58cef8"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-447b-47ca-a073-72e730b82c7d"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-137b-47ca-a073-55e730b82c6d"),
                column: "OrderNumber",
                value: (short)8);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-447b-47ca-a073-72e730b82c6d"),
                column: "OrderNumber",
                value: (short)7);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJZ4eBKE0ETdmio7PTeP/aJJ8JflhivuMjBqwu9eLexZH2WZEZLhuU2B9z9XwIXI/g==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 14, 16, 55, 59, 698, DateTimeKind.Local).AddTicks(6098));
        }
    }
}
