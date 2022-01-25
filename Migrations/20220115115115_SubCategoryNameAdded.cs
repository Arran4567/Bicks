using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class SubCategoryNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategory",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SubCategory",
                newName: "Id");
        }
    }
}
