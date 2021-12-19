using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class EventHistoryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "EventHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ComplaintEventHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeId = table.Column<int>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    ComplaintId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintEventHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComplaintEventHistories_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplaintEventHistories_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplaintEventHistories_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobEventHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeId = table.Column<int>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    JobId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEventHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobEventHistories_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobEventHistories_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobEventHistories_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuoteEventHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeId = table.Column<int>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    QuoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteEventHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuoteEventHistories_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuoteEventHistories_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuoteEventHistories_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemEventHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeId = table.Column<int>(nullable: true),
                    AspNetUserId = table.Column<string>(nullable: true),
                    WhenCreated = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    WorkItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemEventHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkItemEventHistories_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItemEventHistories_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItemEventHistories_WorkItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintEventHistories_AspNetUserId",
                table: "ComplaintEventHistories",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintEventHistories_ComplaintId",
                table: "ComplaintEventHistories",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintEventHistories_EventTypeId",
                table: "ComplaintEventHistories",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEventHistories_AspNetUserId",
                table: "JobEventHistories",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEventHistories_EventTypeId",
                table: "JobEventHistories",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEventHistories_JobId",
                table: "JobEventHistories",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteEventHistories_AspNetUserId",
                table: "QuoteEventHistories",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteEventHistories_EventTypeId",
                table: "QuoteEventHistories",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteEventHistories_QuoteId",
                table: "QuoteEventHistories",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemEventHistories_AspNetUserId",
                table: "WorkItemEventHistories",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemEventHistories_EventTypeId",
                table: "WorkItemEventHistories",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemEventHistories_WorkItemId",
                table: "WorkItemEventHistories",
                column: "WorkItemId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_AspNetUsers_AspNetUserId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Assignments_AssignmentId",
                table: "WorkItems");

            migrationBuilder.DropTable(
                name: "ComplaintEventHistories");

            migrationBuilder.DropTable(
                name: "JobEventHistories");

            migrationBuilder.DropTable(
                name: "QuoteEventHistories");

            migrationBuilder.DropTable(
                name: "WorkItemEventHistories");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "EventHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventTypeId = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventHistories_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventHistories_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventHistories_AspNetUserId",
                table: "EventHistories",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventHistories_EventTypeId",
                table: "EventHistories",
                column: "EventTypeId");

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
        }
    }
}
