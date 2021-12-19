using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class AddNotNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_AspNetUsers_AspNetUserId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_Complaints_ComplaintId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_EventTypes_EventTypeId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_AspNetUsers_AspNetUserId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_EventTypes_EventTypeId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_Jobs_JobId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_AspNetUsers_AspNetUserId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_EventTypes_EventTypeId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_Quotes_QuoteId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Assignments_AssignmentId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AspNetUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Assignments_AssignmentId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_AspNetUsers_AspNetUserId",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_AspNetUsers_AspNetUserId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_EventTypes_EventTypeId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_Tasks_WorkItemId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians");

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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkItemId",
                table: "WorkItemEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "WorkItemEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "WorkItemEventHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Technicians",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Quotes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuoteId",
                table: "QuoteEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "QuoteEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "QuoteEventHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobStatuses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "JobEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "JobEventHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EventTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Complaints",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "ComplaintEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComplaintId",
                table: "ComplaintEventHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "ComplaintEventHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "WorkItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "WorkItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "WorkItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkItems",
                table: "WorkItems",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "WorkItemObject",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemObject", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_AspNetUsers_AspNetUserId",
                table: "ComplaintEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_Complaints_ComplaintId",
                table: "ComplaintEventHistories",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_EventTypes_EventTypeId",
                table: "ComplaintEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_AspNetUsers_AspNetUserId",
                table: "JobEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_EventTypes_EventTypeId",
                table: "JobEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_Jobs_JobId",
                table: "JobEventHistories",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_AspNetUsers_AspNetUserId",
                table: "QuoteEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_EventTypes_EventTypeId",
                table: "QuoteEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_Quotes_QuoteId",
                table: "QuoteEventHistories",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Assignments_AssignmentId",
                table: "Quotes",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_AspNetUsers_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_AspNetUsers_AspNetUserId",
                table: "WorkItemEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_EventTypes_EventTypeId",
                table: "WorkItemEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_WorkItems_WorkItemId",
                table: "WorkItemEventHistories",
                column: "WorkItemId",
                principalTable: "WorkItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_AspNetUsers_AspNetUserId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_Complaints_ComplaintId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintEventHistories_EventTypes_EventTypeId",
                table: "ComplaintEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_AspNetUsers_AspNetUserId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_EventTypes_EventTypeId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEventHistories_Jobs_JobId",
                table: "JobEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_AspNetUsers_AspNetUserId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_EventTypes_EventTypeId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteEventHistories_Quotes_QuoteId",
                table: "QuoteEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Assignments_AssignmentId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_AspNetUsers_AspNetUserId",
                table: "Technicians");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_AspNetUsers_AspNetUserId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_EventTypes_EventTypeId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItemEventHistories_WorkItems_WorkItemId",
                table: "WorkItemEventHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_AspNetUsers_AspNetUserId",
                table: "WorkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_Assignments_AssignmentId",
                table: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemObject");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians");

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

            migrationBuilder.AlterColumn<int>(
                name: "WorkItemId",
                table: "WorkItemEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "WorkItemEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "WorkItemEventHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Technicians",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Quotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "QuoteId",
                table: "QuoteEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "QuoteEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "QuoteEventHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "JobStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "JobEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "JobEventHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EventTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventTypeId",
                table: "ComplaintEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ComplaintId",
                table: "ComplaintEventHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "ComplaintEventHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Postcode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoneNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId",
                unique: true,
                filter: "[AspNetUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_AspNetUsers_AspNetUserId",
                table: "ComplaintEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_Complaints_ComplaintId",
                table: "ComplaintEventHistories",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintEventHistories_EventTypes_EventTypeId",
                table: "ComplaintEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Assignments_AssignmentId",
                table: "Complaints",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_AspNetUsers_AspNetUserId",
                table: "JobEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_EventTypes_EventTypeId",
                table: "JobEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEventHistories_Jobs_JobId",
                table: "JobEventHistories",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_AspNetUsers_AspNetUserId",
                table: "QuoteEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_EventTypes_EventTypeId",
                table: "QuoteEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteEventHistories_Quotes_QuoteId",
                table: "QuoteEventHistories",
                column: "QuoteId",
                principalTable: "Quotes",
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
                name: "FK_Technicians_AspNetUsers_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_AspNetUsers_AspNetUserId",
                table: "WorkItemEventHistories",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_EventTypes_EventTypeId",
                table: "WorkItemEventHistories",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItemEventHistories_Tasks_WorkItemId",
                table: "WorkItemEventHistories",
                column: "WorkItemId",
                principalTable: "Tasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");
        }
    }
}
