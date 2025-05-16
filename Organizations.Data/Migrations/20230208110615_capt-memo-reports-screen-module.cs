using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class captmemoreportsscreenmodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("a5373e90-2292-42f3-a44e-1c42ea55cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"), new Guid("246d3f84-55a1-49ce-bde1-113bdde72944") },
                    { new Guid("a5373e90-2292-42f3-a44e-1c42ea56cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"), new Guid("256d3f82-55a1-49ce-bde1-113bdde72944") },
                    { new Guid("a5373e90-2292-42f3-a44e-1c42ea57cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"), new Guid("256d3f91-55a1-49ce-bde1-113bdde72944") }
                });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAVmBw7rNWsA8qbFuzT18hr58mRGb5GulVDIQ+Nf0liG8ConSLmbzL0B7/xQdjD5SQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 8, 13, 6, 12, 670, DateTimeKind.Local).AddTicks(1833));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-2292-42f3-a44e-1c42ea55cef9"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-2292-42f3-a44e-1c42ea56cef9"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-2292-42f3-a44e-1c42ea57cef9"));

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
    }
}
