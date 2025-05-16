using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class editinorgsettingisIsActiveDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ADKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_PrimaryKeyId",
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsActiveDirectory",
                table: "OrganizationSetting",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "ADKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPMIugHPBni2h9viAWH5z59lweb7aH4J7qMd7GRPm2PXYvTGgqODfJXyMDwNwAiXag==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 29, 17, 37, 59, 700, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ADKeyId",
                table: "OrganizationSetting",
                column: "ADKeyId",
                principalTable: "ActiveDirectoryKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_PrimaryKeyId",
                table: "OrganizationSetting",
                column: "PrimaryKeyId",
                principalTable: "ActiveDirectoryPrimaryKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryKeys_ADKeyId",
                table: "OrganizationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_PrimaryKeyId",
                table: "OrganizationSetting");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryKeyId",
                table: "OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActiveDirectory",
                table: "OrganizationSetting",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
                value: "AQAAAAEAACcQAAAAEM+XKtOp+nc9F7YQgza9v2POR7Bop6Y30ijchWepdvYObuQpKK+rp4rxTrLb75C6+A==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 11, 14, 23, 28, 289, DateTimeKind.Local).AddTicks(1324));

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
    }
}
