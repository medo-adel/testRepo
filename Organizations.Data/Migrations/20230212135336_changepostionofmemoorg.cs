using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class changepostionofmemoorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-38a1-49ce-bde1-103bdde72943"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)15, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090") });

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-55a1-49ce-bde1-103bdde72944"),
                column: "OrderNumber",
                value: (short)12);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("246d3f84-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)13);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f82-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)14);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)15);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAED/FeKAJdpSLUTBebQL+xY9A8aFg2ZqHWSA5NntGqY9klUHRedQzvpG8qOXoeG4o7A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 12, 15, 53, 33, 388, DateTimeKind.Local).AddTicks(6478));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-38a1-49ce-bde1-103bdde72943"),
                columns: new[] { "OrderNumber", "ParentId" },
                values: new object[] { (short)12, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef") });

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-55a1-49ce-bde1-103bdde72944"),
                column: "OrderNumber",
                value: (short)13);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("246d3f84-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)14);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f82-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)15);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("256d3f91-55a1-49ce-bde1-113bdde72944"),
                column: "OrderNumber",
                value: (short)16);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEL41qlYYAwEie2IfBb4qT29wP9suQdZHT5JthuDnNkV3jL12US7kY5UAkQocEdsw+A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 9, 13, 14, 27, 915, DateTimeKind.Local).AddTicks(2690));
        }
    }
}
