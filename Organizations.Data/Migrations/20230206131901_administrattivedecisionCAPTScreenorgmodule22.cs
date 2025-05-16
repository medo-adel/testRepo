using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class administrattivedecisionCAPTScreenorgmodule22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-38a1-49ce-bde1-103bdde72943"),
                column: "IsReport",
                value: false);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGwYgDTVbT8JyilHMsk1mIEqS45Az/sOF7oPwHZt+ItuRjpeCDjOsNL0dxtxiM931w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 6, 15, 18, 57, 218, DateTimeKind.Local).AddTicks(8826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("146d3f84-38a1-49ce-bde1-103bdde72943"),
                column: "IsReport",
                value: true);

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
    }
}
