using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class updateinactivedirectoryseeting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ActiveDirectoryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "ActiveDirectoryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ADKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_ADKeyId",
                table: "OrganizationSetting",
                column: "ADKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_PrimaryKeyId",
                table: "OrganizationSetting",
                column: "PrimaryKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ADKeyId",
                table: "OrganizationSetting",
                column: "ADKeyId",
                principalTable: "ActiveDirectoryKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_PrimaryKeyId",
                table: "OrganizationSetting",
                column: "PrimaryKeyId",
                principalTable: "ActiveDirectoryPrimaryKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ADKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_PrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationSetting_ADKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationSetting_PrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ADKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryPrimaryKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryKeyId",
                principalTable: "ActiveDirectoryKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryPrimaryKeyId",
                principalTable: "ActiveDirectoryPrimaryKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
