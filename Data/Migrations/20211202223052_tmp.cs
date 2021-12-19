using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class tmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Products_ProductId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobStatusId",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId",
                unique: true,
                filter: "[AspNetUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Products_ProductId",
                table: "Jobs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Products_ProductId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "JobStatusId",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_AspNetUserId",
                table: "Technicians",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Assignments_AssignmentId",
                table: "Jobs",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Products_ProductId",
                table: "Jobs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
