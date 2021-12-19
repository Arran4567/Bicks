using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class InitialSeedAndSchemaChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_EventHistories_EventHistoryId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_EventHistories_Assignments_AssignmentId",
                table: "EventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_EventHistories_EventHistoryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_EventHistories_EventHistoryId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_EventHistories_EventId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EventId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_EventHistoryId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EventHistoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_EventHistories_AssignmentId",
                table: "EventHistories");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_EventHistoryId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EventHistoryId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "EventHistoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "EventHistories");

            migrationBuilder.DropColumn(
                name: "ForeignId",
                table: "EventHistories");

            migrationBuilder.DropColumn(
                name: "EventHistoryId",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Quotes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Complaints",
                nullable: true);

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Job" });

            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Job Created" },
                    { 2, "Picked Up" },
                    { 3, "On Site" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignmentId",
                table: "Tasks",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AssignmentId",
                table: "Quotes",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AssignmentId",
                table: "Jobs",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AssignmentId",
                table: "Complaints",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Assignments_AssignmentId",
                table: "Quotes",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Assignments_AssignmentId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignmentId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_AssignmentId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AssignmentId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AssignmentId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Complaints");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventHistoryId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventHistoryId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "EventHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForeignId",
                table: "EventHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventHistoryId",
                table: "Complaints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EventId",
                table: "Tasks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_EventHistoryId",
                table: "Quotes",
                column: "EventHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EventHistoryId",
                table: "Jobs",
                column: "EventHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventHistories_AssignmentId",
                table: "EventHistories",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_EventHistoryId",
                table: "Complaints",
                column: "EventHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_EventHistories_EventHistoryId",
                table: "Complaints",
                column: "EventHistoryId",
                principalTable: "EventHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventHistories_Assignments_AssignmentId",
                table: "EventHistories",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_EventHistories_EventHistoryId",
                table: "Jobs",
                column: "EventHistoryId",
                principalTable: "EventHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_EventHistories_EventHistoryId",
                table: "Quotes",
                column: "EventHistoryId",
                principalTable: "EventHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_EventHistories_EventId",
                table: "Tasks",
                column: "EventId",
                principalTable: "EventHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
