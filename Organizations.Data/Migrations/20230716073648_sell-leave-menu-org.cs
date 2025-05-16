using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class sellleavemenuorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c486e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)11);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c496e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)9);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c506e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)10);

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[] { new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945333"), true, "SellLeaveBalancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "timeline", false, false, null, null, (short)8, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/leaves/sell-leave-balances" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945333"));

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c486e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)10);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c496e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)8);

            migrationBuilder.UpdateData(
                table: "OrganizationScreens",
                keyColumn: "Id",
                keyValue: new Guid("c506e9c7-fc23-4bec-bb17-a7a1da945632"),
                column: "OrderNumber",
                value: (short)9);

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"),
                column: "Password",
                value: "AQAAAAEAACcQAAAAENR+ZZRjgBKm+xfPqR8cFTZ5t6boVzgNrgCxPqK4U288tUJLQRViPcnarBdBmmj7uA==");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 15, 11, 27, 20, 141, DateTimeKind.Local).AddTicks(5266));
        }
    }
}
