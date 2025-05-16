using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class sellleavemodulescreenorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("13f33345-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945333") });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAELe5K8zUwN87FX2W4Wf/BdVcLkKNOL43GIEY9EmueSpwJgyMyA7Y6hJibPdS0po/8Q==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 16, 10, 41, 20, 713, DateTimeKind.Local).AddTicks(4791));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleScreens",
                keyColumn: "Id",
                keyValue: new Guid("13f33345-9bba-478c-8da9-e6439f75d0a8"));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGrsy0Phob4mlKXdRJDUp5ZN5TBweOE4a8ywzMVcz8wnM9OjSrcJsO88QFNAv+a+Og==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 16, 10, 36, 45, 737, DateTimeKind.Local).AddTicks(7101));
        }
    }
}
