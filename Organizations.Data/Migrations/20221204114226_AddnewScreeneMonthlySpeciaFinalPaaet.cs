using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AddnewScreeneMonthlySpeciaFinalPaaet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("146d3f84-36a1-49ce-bde1-103bdde75742"), true, "MonthlySpeciaFinalPaaetReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)26, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/monthly-specia-final-paaet-report" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOJ39KACtUA6/O+kbc0bCmh8zyMwY5J+JUUZbSh+QhUcJt75xKLTd13LRqqAgKTHQQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 4, 13, 42, 24, 192, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("3bde3840-3b77-4854-a229-ae5d7d622531"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-36a1-49ce-bde1-103bdde75742") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde3840-3b77-4854-a229-ae5d7d622531"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-36a1-49ce-bde1-103bdde75742"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPT9fOSEdii/xoCDLJOh0G1ppp7Jnu2VInrRFcwXV/TPHJl9y7TCRwzt3XtBTnM3CQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 29, 12, 57, 4, 342, DateTimeKind.Local).AddTicks(507));
        }
    }
}
