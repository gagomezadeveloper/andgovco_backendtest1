using Microsoft.EntityFrameworkCore.Migrations;

namespace AndGovCo_backendTest_1.Migrations
{
    public partial class ProductoTypeCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductoType_ProductTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProducTypeID",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeID",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductoType_ProductTypeID",
                table: "Product",
                column: "ProductTypeID",
                principalTable: "ProductoType",
                principalColumn: "ProductTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductoType_ProductTypeID",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProducTypeID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductoType_ProductTypeID",
                table: "Product",
                column: "ProductTypeID",
                principalTable: "ProductoType",
                principalColumn: "ProductTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
