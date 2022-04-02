using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class ItemWeightsAddedToInvoiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemWeights",
                table: "InvoiceItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemWeights",
                table: "InvoiceItems");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalWeight",
                table: "InvoiceItems",
                type: "Decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
