using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class updateinactivedirectory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKey_ActiveDirectoryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActiveDirectoryKey",
                table: "ActiveDirectoryKey");

            migrationBuilder.RenameTable(
                name: "ActiveDirectoryKey",
                newName: "ActiveDirectoryKeys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActiveDirectoryKeys",
                table: "ActiveDirectoryKeys",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEJ+kW81UjA6QeyhlAZF6aFpwUBoj/AmqOAcqUIaJ70VAtshZfM12p1YiShcX/wPRJQ==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 16, 15, 47, 54, 567, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryKeyId",
                principalTable: "ActiveDirectoryKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ActiveDirectoryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActiveDirectoryKeys",
                table: "ActiveDirectoryKeys");

            migrationBuilder.RenameTable(
                name: "ActiveDirectoryKeys",
                newName: "ActiveDirectoryKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActiveDirectoryKey",
                table: "ActiveDirectoryKey",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEpxxDh8FNusovUaY0GgTu0cblnRRXvTadquFpjhbvthI0WSZzZpTHA0filVHe9rug==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 16, 15, 43, 19, 293, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKey_ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryKeyId",
                principalTable: "ActiveDirectoryKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
