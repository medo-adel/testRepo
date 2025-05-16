using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class fogetsign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[] { new Guid("8641f18d-17ba-4974-9f8b-d74472f81543"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Forget Sign)", "Workflow Module - (Forget Sign)", null });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM4Q5jTKLUxkxnJQobshI/MY3+jemdKH0UJO1udzBw0tKacQ+NaW8cKnDLSVKCR/CA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 12, 8, 48, 602, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("6bde3830-3b65-4854-a189-ae4d7d641835"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8641f18d-17ba-4974-9f8b-d74472f81543"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab4-5a15-491c-843f-e4596570d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("8641f18d-17ba-4974-9f8b-d74472f81543"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("6bde3830-3b65-4854-a189-ae4d7d641835"));

            migrationBuilder.DeleteData(
                table: "PackageModules",
                keyColumn: "Id",
                keyValue: new Guid("d96baab4-5a15-491c-843f-e4596570d6a8"));

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: new Guid("8641f18d-17ba-4974-9f8b-d74472f81543"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBx4WzollRF5qsddv3VFQhcgNQGeZ5kS9V2fPmTo6MZIJdPrLHZNoGp+fVbhr7t9xQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 16, 16, 28, 16, 804, DateTimeKind.Local).AddTicks(2924));
        }
    }
}
