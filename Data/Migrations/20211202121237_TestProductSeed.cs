using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class TestProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 1, "This is a test product", "Test Product", 2.15m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
