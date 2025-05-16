using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class editphiscalrelationinorglicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationLicenseRequests_OrganizationRequests_OrganizationId",
                table: "OrganizationLicenseRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationRequestId",
                table: "OrganizationLicenseRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENp0p1hLZHOmTEnJr+dSwSvz71EFsfkoI353337ZjqiPBBh49jecQd+1pMWCvOgJnw==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 21, 16, 31, 21, 975, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenseRequests_OrganizationRequestId",
                table: "OrganizationLicenseRequests",
                column: "OrganizationRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationLicenseRequests_OrganizationRequests_OrganizationRequestId",
                table: "OrganizationLicenseRequests",
                column: "OrganizationRequestId",
                principalTable: "OrganizationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationLicenseRequests_Organizations_OrganizationId",
                table: "OrganizationLicenseRequests",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationLicenseRequests_OrganizationRequests_OrganizationRequestId",
                table: "OrganizationLicenseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationLicenseRequests_Organizations_OrganizationId",
                table: "OrganizationLicenseRequests");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationLicenseRequests_OrganizationRequestId",
                table: "OrganizationLicenseRequests");

            migrationBuilder.DropColumn(
                name: "OrganizationRequestId",
                table: "OrganizationLicenseRequests");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEH2aoMRIvKf1CiVkNVTgX/BYQR5u8LZGk2u+/89juLa0t5MaJPZXGyq4dgiPiBvVXQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 17, 12, 46, 56, 229, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationLicenseRequests_OrganizationRequests_OrganizationId",
                table: "OrganizationLicenseRequests",
                column: "OrganizationId",
                principalTable: "OrganizationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
