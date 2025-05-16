using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class AddFaceRegistrationSupinMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("93ee3f27-6a95-46e4-b199-8aa86225d85c"), true, "FaceRegistration", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_identity", false, false, null, null, (short)6, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/user-face" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBHa7zuvLB49RFJvowUwhOZJfZ1QIaLp5kfG+7axlm5INbhfwNgslEEBcBgvMAmRPA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 7, 14, 136, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 7, 14, 151, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("ba3f5f24-d71d-4eda-11b2-ceaf4ae6e84d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("93ee3f27-6a95-46e4-b199-8aa86225d85c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("ba3f5f24-d71d-4eda-11b2-ceaf4ae6e84d"));

            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("93ee3f27-6a95-46e4-b199-8aa86225d85c"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEP4OtXmQ9z7g8HqstdzUJfdnN8KeViOpGpKEWkCknKFh8iAtdiIFqx9bozL7CygzWw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 12, 16, 50, 53, 866, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 12, 16, 50, 53, 884, DateTimeKind.Local).AddTicks(7442));
        }
    }
}
