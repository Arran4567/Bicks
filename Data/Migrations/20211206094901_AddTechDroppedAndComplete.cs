using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Data.Migrations
{
    public partial class AddTechDroppedAndComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 4, "Technician Dropped Job" });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "ID", "Name" },
                values: new object[] { 5, "Technician Completed Job" });

            migrationBuilder.InsertData(
                table: "JobStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 4, "Completed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobStatuses",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
