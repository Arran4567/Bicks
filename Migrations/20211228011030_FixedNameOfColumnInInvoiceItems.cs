using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class FixedNameOfColumnInInvoiceItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Sales_SaleInvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_SaleInvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "SaleInvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "InvoiceItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_SaleId",
                table: "InvoiceItems",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Sales_SaleId",
                table: "InvoiceItems",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Sales_SaleId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_SaleId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<int>(
                name: "SaleInvoiceItems",
                table: "InvoiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_SaleInvoiceItems",
                table: "InvoiceItems",
                column: "SaleInvoiceItems");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Sales_SaleInvoiceItems",
                table: "InvoiceItems",
                column: "SaleInvoiceItems",
                principalTable: "Sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
