using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class AddedBasicQuoteStatusAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueWhen",
                table: "Quotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuoteStatusId",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuoteTypeId",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuoteStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuoteTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTypes", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "QuoteStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Quote Created" },
                    { 2, "Survey Scheduled" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "QuoteTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Desktop Quote" },
                    { 2, "Survey Quote" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteStatusId",
                table: "Quotes",
                column: "QuoteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteTypeId",
                table: "Quotes",
                column: "QuoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteStatuses_QuoteStatusId",
                table: "Quotes",
                column: "QuoteStatusId",
                principalTable: "QuoteStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteTypes_QuoteTypeId",
                table: "Quotes",
                column: "QuoteTypeId",
                principalTable: "QuoteTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteStatuses_QuoteStatusId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteTypes_QuoteTypeId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteStatuses");

            migrationBuilder.DropTable(
                name: "QuoteTypes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuoteStatusId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuoteTypeId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "DueWhen",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteStatusId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteTypeId",
                table: "Quotes");
        }
    }
}
