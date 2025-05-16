using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class assigndutytoadminstrationwithScreen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("e8a82e92-137b-47ca-a073-55e730b82c6d"), true, "AssignDutyWithAdminstrationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "person_add", false, false, null, null, (short)8, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/assign-duty-with-adminstrations" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOY5++LZRwWVhyDahngwKsK/SDpb0+xJc6Jewx726CMig7YdmQbrC2dJ6xatKkO/eQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 17, 4, 7, 875, DateTimeKind.Local).AddTicks(4678));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("e8a82e92-137b-47ca-a073-55e730b82c6d"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELp/XmDttwAAdsXwxA6zuUyqsajUAmC0TsmrTTSqOoZ9rMC0ODIv98KzRp+Q9peRHg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 13, 11, 32, 6, 314, DateTimeKind.Local).AddTicks(433));
        }
    }
}
