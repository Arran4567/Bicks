using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class RemovedApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "EventHistories");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "EventHistories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 1, "Hi", "Item 1", 2.0m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 2, "Hi", "Item 2", 2.0m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 3, "Hi", "Item 3", 2.0m });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AspNetUserId",
                table: "Tasks",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventHistories_AspNetUserId",
                table: "EventHistories",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventHistories_AspNetUsers_AspNetUserId",
                table: "EventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventHistories_AspNetUsers_AspNetUserId",
                table: "EventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_EventHistories_AspNetUserId",
                table: "EventHistories");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "EventHistories");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "EventHistories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
