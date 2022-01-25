using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class AddedStockToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CasesInStock",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CasesInStock",
                table: "Products");
        }
    }
}
