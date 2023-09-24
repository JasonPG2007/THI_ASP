using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Intinal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, "Ngô Văn Lợi" },
                    { 2, "Hoàng Văng Tấn" },
                    { 3, "Đào Hải Nam" },
                    { 4, "Trần Thị Huyền" },
                    { 5, "Nguyễn Văn Lực" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Laptop MSI 2022", 3000.0, 200 },
                    { 2, "Laptop ACER 2023", 2500.0, 220 },
                    { 3, "Laptop ASUS 2022", 2700.0, 220 },
                    { 4, "Laptop DELL 2022", 3900.0, 220 },
                    { 5, "Laptop HP 2021", 1900.0, 220 },
                    { 6, "Laptop MSI 2023", 4000.0, 220 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CreatedDate", "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 1, "2023 - 07 - 01", 3, 1 },
                    { 2, "2023 - 07 - 01", 2, 5 },
                    { 3, "2023 - 07 - 01", 2, 4 },
                    { 4, "2023 - 06 - 30", 1, 3 },
                    { 5, "2023 - 06 - 30", 1, 2 },
                    { 6, "2023 - 06 - 30", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
