using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class orgrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationRequestId",
                table: "OrganizationHosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganizationRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AlternativeEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PrimaryLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURLFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURLSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPromise = table.Column<bool>(type: "bit", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationRequests_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLicenseRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersCount = table.Column<int>(type: "int", nullable: false),
                    EmployeesCount = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLicenseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenseRequests_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenseRequests_OrganizationRequests_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "OrganizationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenseRequests_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLicencesModuleRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationLicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLicencesModuleRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationLicencesModuleRequests_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationLicencesModuleRequests_OrganizationLicenseRequests_OrganizationLicenseId",
                        column: x => x.OrganizationLicenseId,
                        principalTable: "OrganizationLicenseRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJdiolO+kQWLSyiejSTZlajPptcdzSkfx13AKorLBEerO+F5o8gyruoEkOx8m8mioA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 2, 11, 45, 37, 601, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationHosts_OrganizationRequestId",
                table: "OrganizationHosts",
                column: "OrganizationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicencesModuleRequests_ModuleId",
                table: "OrganizationLicencesModuleRequests",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicencesModuleRequests_OrganizationLicenseId",
                table: "OrganizationLicencesModuleRequests",
                column: "OrganizationLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenseRequests_ApplicationId",
                table: "OrganizationLicenseRequests",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenseRequests_OrganizationId",
                table: "OrganizationLicenseRequests",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenseRequests_PackageId",
                table: "OrganizationLicenseRequests",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationRequests_TimeZoneId",
                table: "OrganizationRequests",
                column: "TimeZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationHosts_OrganizationRequests_OrganizationRequestId",
                table: "OrganizationHosts",
                column: "OrganizationRequestId",
                principalTable: "OrganizationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationHosts_OrganizationRequests_OrganizationRequestId",
                table: "OrganizationHosts");

            migrationBuilder.DropTable(
                name: "OrganizationLicencesModuleRequests");

            migrationBuilder.DropTable(
                name: "OrganizationLicenseRequests");

            migrationBuilder.DropTable(
                name: "OrganizationRequests");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationHosts_OrganizationRequestId",
                table: "OrganizationHosts");

            migrationBuilder.DropColumn(
                name: "OrganizationRequestId",
                table: "OrganizationHosts");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEC38baqxPqzKED9BhUxDhxc9fQbXwRdSKEqsFpTWPBHqKHAHKu02pa61f9vQQAx7jQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2024, 6, 26, 16, 54, 40, 869, DateTimeKind.Local).AddTicks(6714));
        }
    }
}
