using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class _remove_publicseed_org : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "AQAAAAEAACcQAAAAEP3U2XldfG7NuCNTTvXYXh+UtDmVGwcCmonja62xZRGaPGZvp+mDx2Sp1YQHYfi74w==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 19, 11, 35, 54, 627, DateTimeKind.Local).AddTicks(7234));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEBnRgSR4JNEKFlunQEqsWxgBu9T7gSO0TNIJRgY+gYWYcwvzX3fF+K25+qE7kFzgKQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 13, 13, 46, 44, 54, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AdminPassword", "AlternativeEmail", "Code", "CreatedBy", "CreatedDate", "Encryption", "IsDelete", "IsPromise", "LogoURLFl", "LogoURLSl", "ModifiedBy", "ModifiedDate", "NickName", "OrganizationId", "OrganizationNameFl", "OrganizationNameSl", "OrganizationTypeId", "PrimaryLanguage", "RegistrationEmail", "SecondaryLanguage", "TimeZoneId" },
                values: new object[] { new Guid("038efd7f-9bcf-42f4-3819-08d715a43532"), "EbDPTSTEwAqG91Jysjs8SA==", "tech@apexunited.com", "public", new Guid("b31871ee-4e10-4d5a-9193-a1272b51b3be"), new DateTime(2025, 2, 13, 13, 46, 44, 64, DateTimeKind.Local).AddTicks(4750), "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f", false, true, null, null, null, null, "Public", null, "public", "عام", null, "EN", "tech@apexunited.com", "AR", null });
        }
    }
}
