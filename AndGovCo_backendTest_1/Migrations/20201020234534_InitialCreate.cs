using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AndGovCo_backendTest_1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductoType",
                columns: table => new
                {
                    ProductTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoType", x => x.ProductTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductState",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Serial = table.Column<string>(nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "money", nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    ProductStateID = table.Column<int>(nullable: false),
                    ProducTypeID = table.Column<int>(nullable: false),
                    AreaID = table.Column<int>(nullable: true),
                    ProductTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductState_ProductStateID",
                        column: x => x.ProductStateID,
                        principalTable: "ProductState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductoType_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductoType",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_AreaID",
                table: "Product",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductStateID",
                table: "Product",
                column: "ProductStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "ProductState");

            migrationBuilder.DropTable(
                name: "ProductoType");
        }
    }
}
