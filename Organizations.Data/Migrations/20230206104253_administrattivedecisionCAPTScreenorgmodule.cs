using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class administrattivedecisionCAPTScreenorgmodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("a5373e90-5892-42f3-a55e-1c42ea59cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db22585c-f708-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-38a1-49ce-bde1-103bdde72943") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELKV8jb9uhmRBZI2vee2uZV5Ld/UAYzY9ohXIA2ZicKpmokwJO1+v6fY5GIyxfLilw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 6, 12, 42, 50, 237, DateTimeKind.Local).AddTicks(8625));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("a5373e90-5892-42f3-a55e-1c42ea59cef9"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJsdpZRFVeMtTrGDzIl2YRzYG6CXn9+e/8Ehv9/IjeQfdTj89yK+/fhr8iiVzdWK1w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 6, 12, 40, 35, 985, DateTimeKind.Local).AddTicks(9210));
        }
    }
}
