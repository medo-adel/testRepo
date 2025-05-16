using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class WorkflowStatusNotApprovedComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("54ee3f36-6a95-98e6-b177-8aa861850002"), true, "WorkflowStatusNotApprovedComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dashboard", false, false, null, null, (short)2, new Guid("54ee3f27-6a95-98e4-c188-6bb86119d85c"), "/main/workflows/workflow-status-not-approved" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEDLHs42Ol2hLsOt4gcq0BMHtNw1+apN88/eDpt8HDSksA5Jh0BtAgw27mQqaeJ0/yQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 17, 14, 31, 16, 599, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("3bde4830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("10efc918-ef1f-409a-a0b3-ee5d35932997"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850002") },
                    { new Guid("4bde5830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58011"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850002") },
                    { new Guid("5bde6830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81522"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850002") },
                    { new Guid("6bde7830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81533"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850002") },
                    { new Guid("6bde8830-3b65-4854-a189-ae4d7d641835"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8641f18d-17ba-4974-9f8b-d74472f81543"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850002") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("3bde4830-3b65-4854-a289-ae4d7d641825"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("4bde5830-3b65-4854-a289-ae4d7d641825"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("5bde6830-3b65-4854-a289-ae4d7d641825"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("6bde7830-3b65-4854-a289-ae4d7d641825"));

            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("6bde8830-3b65-4854-a189-ae4d7d641835"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("54ee3f36-6a95-98e6-b177-8aa861850002"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOnj7nEXF5ijRB8v2MMs4IQLN+TXeSyfKBSuaV1RIKHrT+E1E29oFaqv3rALFk6iIQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 16, 11, 30, 13, 430, DateTimeKind.Local).AddTicks(504));
        }
    }
}
