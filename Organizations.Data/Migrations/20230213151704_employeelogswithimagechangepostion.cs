using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class employeelogswithimagechangepostion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-33a1-48ce-bde3-103bdde71331"),
                column: "OrderNumber",
                value: (short)20);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-33a1-48ce-bde3-103bdde71332"),
                column: "OrderNumber",
                value: (short)22);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-36a1-49ce-bde1-103bdde75742"),
                column: "OrderNumber",
                value: (short)23);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85742"),
                column: "OrderNumber",
                value: (short)24);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85752"),
                column: "OrderNumber",
                value: (short)25);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85762"),
                column: "OrderNumber",
                value: (short)26);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("ab368b4c-9c18-3309-aa0b-f350ba8fe449"),
                columns: new[] { "IconName", "OrderNumber", "ParentId" },
                values: new object[] { "data_usage", (short)19, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEHOJyRlXB84ATA46cK2P2pFv2W5aOwuwJCNGS06xtM7BUQFQSIIO4o+adctl3+kCWg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 13, 17, 17, 0, 731, DateTimeKind.Local).AddTicks(5821));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-33a1-48ce-bde3-103bdde71331"),
                column: "OrderNumber",
                value: (short)19);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-33a1-48ce-bde3-103bdde71332"),
                column: "OrderNumber",
                value: (short)20);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-36a1-49ce-bde1-103bdde75742"),
                column: "OrderNumber",
                value: (short)22);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85742"),
                column: "OrderNumber",
                value: (short)23);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85752"),
                column: "OrderNumber",
                value: (short)24);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-46a1-49ce-bde1-103bdde85762"),
                column: "OrderNumber",
                value: (short)25);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("ab368b4c-9c18-3309-aa0b-f350ba8fe449"),
                columns: new[] { "IconName", "OrderNumber", "ParentId" },
                values: new object[] { "fingerprint", (short)7, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEO58WjqUNYRmhDmj8Gp8r/RiUxhdZXd1OmDVoPKrpNfKOiADfDtQ9T/mMjU4xfJSA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 13, 10, 24, 17, 507, DateTimeKind.Local).AddTicks(8886));
        }
    }
}
