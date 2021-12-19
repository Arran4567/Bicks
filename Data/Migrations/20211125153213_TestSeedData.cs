using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class TestSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Status 1" });

            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Status 2" });

            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Status 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
