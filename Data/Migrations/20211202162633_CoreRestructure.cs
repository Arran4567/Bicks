using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class CoreRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_WorkItems_WorkItemId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_AspNetUsers_AspNetUserId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Assignments_AssignmentId",
                table: "WorkItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems");

            migrationBuilder.RenameTable(
                name: "WorkItems",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItems_AssignmentId",
                table: "Tasks",
                newName: "IX_Tasks_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkItems_AspNetUserId",
                table: "Tasks",
                newName: "IX_Tasks_AspNetUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_Tasks_WorkItemId",
                table: "WorkItemEventHistories",
                column: "WorkItemId",
                principalTable: "Tasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_Tasks_WorkItemId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "WorkItems");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignmentId",
                table: "WorkItems",
                newName: "IX_WorkItems_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AspNetUserId",
                table: "WorkItems",
                newName: "IX_WorkItems_AspNetUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_WorkItems_WorkItemId",
                table: "WorkItemEventHistories",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_AspNetUsers_AspNetUserId",
                table: "WorkItems",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_Assignments_AssignmentId",
                table: "WorkItems",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
