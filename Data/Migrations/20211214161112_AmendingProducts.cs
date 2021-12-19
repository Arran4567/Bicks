using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class AmendingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Name", "PricePerKg" },
                values: new object[] { 2, "Black Pudding", 2.60m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Name", "PricePerKg" },
                values: new object[] { 3, "Strip Loin", 19.50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
