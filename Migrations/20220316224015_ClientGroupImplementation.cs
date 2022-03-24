using Microsoft.EntityFrameworkCore.Migrations;

namespace Bicks.Migrations
{
    public partial class ClientGroupImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientProductOptions");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerUnit",
                table: "Products",
                type: "Decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PricingMethod",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientGroupID",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientGroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PricePerKgOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true),
                    PricePerUnitOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PricePerKgOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true),
                    PricePerUnitOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: true),
                    NumTimesPurchased = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientGroupID",
                table: "Clients",
                column: "ClientGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ClientID",
                table: "ProductOptions",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientGroup_ClientGroupID",
                table: "Clients",
                column: "ClientGroupID",
                principalTable: "ClientGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientGroup_ClientGroupID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientGroup");

            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientGroupID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PricePerUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PricingMethod",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClientGroupID",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientProductOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    NumTimesPurchased = table.Column<int>(type: "int", nullable: false),
                    PricePerKgOverride = table.Column<decimal>(type: "Decimal(18, 2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProductOptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientProductOptions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProductOptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProductOptions_ClientId",
                table: "ClientProductOptions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProductOptions_ProductId",
                table: "ClientProductOptions",
                column: "ProductId");
        }
    }
}
