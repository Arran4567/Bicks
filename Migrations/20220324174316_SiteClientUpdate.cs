using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class SiteClientUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientGroup_ClientGroupID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientGroup");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientGroupID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientGroupID",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    ContactName = table.Column<string>(nullable: false),
                    ContactPhoneNumber = table.Column<string>(nullable: false),
                    ContactEmail = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    Postcode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Site_ClientID",
                table: "Site",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.AddColumn<int>(
                name: "ClientGroupID",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerKgOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true),
                    PricePerUnitOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGroup", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientGroupID",
                table: "Clients",
                column: "ClientGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientGroup_ClientGroupID",
                table: "Clients",
                column: "ClientGroupID",
                principalTable: "ClientGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
