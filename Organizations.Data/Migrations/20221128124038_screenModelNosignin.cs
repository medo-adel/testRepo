using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class screenModelNosignin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("146d3f84-34a1-49ce-bde1-103bdde75542"), true, "NoSignInPaaetReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)24, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/no-sign-in-paaet-report" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH4KUeeR4wTUJ4BWksmo7d3xDUVyL/Fvnd4Oaigc+oFwCLgA0WuHRsFlbhjm3ykW8Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 14, 40, 36, 454, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("3bde3840-3b75-4854-a229-ae5d7d622331"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-34a1-49ce-bde1-103bdde75542") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3b75-4854-a229-ae5d7d622331"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-34a1-49ce-bde1-103bdde75542"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEB/9gEfHwzP0EXO69RxpovEK15zIm3LH4LC7SgBk2JTv4iQXX9ZgJfpzPt8YfbG9DQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 28, 12, 47, 16, 27, DateTimeKind.Local).AddTicks(2066));
        }
    }
}
