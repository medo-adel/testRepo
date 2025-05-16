using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _add_publicOrgnization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENHLgmBtYq0nIUEzp2VGOqO9ym17w4iZj2Pg/pZO0fgojjQcBkk0ejZv3A42t5dhAA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 15, 48, 55, 330, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AdminPassword", "AlternativeEmail", "Code", "CreatedBy", "CreatedDate", "Encryption", "IsDelete", "IsPromise", "LogoURLFl", "LogoURLSl", "ModifiedBy", "ModifiedDate", "NickName", "OrganizationId", "OrganizationNameFl", "OrganizationNameSl", "OrganizationTypeId", "PrimaryLanguage", "RegistrationEmail", "SecondaryLanguage", "TimeZoneId" },
                values: new object[] { new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"), "EbDPTSTEwAqG91Jysjs8SA==", "tech@apexunited.com", "public", new Guid("b31871ee-4e10-4d5a-9193-a1272b51b3be"), new DateTime(2025, 2, 9, 15, 48, 55, 354, DateTimeKind.Local).AddTicks(4006), "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f", false, true, null, null, null, null, "Public", null, "public", "عام", null, "EN", "tech@apexunited.com", "AR", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENpyNj0OnoRryoThob3YOeC9lwbj75ZigVdAKLQxbyf0sPQwCIKO6eSg3iZ0tbmqsg==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 2, 17, 57, 49, 937, DateTimeKind.Local).AddTicks(7821));
        }
    }
}
