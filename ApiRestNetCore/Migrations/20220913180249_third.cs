using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestNetCore.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSeller",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSeller", x => new { x.ProductId, x.SellerId });
                    table.ForeignKey(
                        name: "FK_ProductSeller_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSeller_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_CustomerId",
                table: "TransactionReports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_OrderId",
                table: "TransactionReports",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_PaymentId",
                table: "TransactionReports",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_ProductId",
                table: "TransactionReports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeller_SellerId",
                table: "ProductSeller",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_Customer_CustomerId",
                table: "TransactionReports",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_Payment_PaymentId",
                table: "TransactionReports",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_Product_ProductId",
                table: "TransactionReports",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_ShoppingOrder_OrderId",
                table: "TransactionReports",
                column: "OrderId",
                principalTable: "ShoppingOrder",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_Customer_CustomerId",
                table: "TransactionReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_Payment_PaymentId",
                table: "TransactionReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_Product_ProductId",
                table: "TransactionReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_ShoppingOrder_OrderId",
                table: "TransactionReports");

            migrationBuilder.DropTable(
                name: "ProductSeller");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_CustomerId",
                table: "TransactionReports");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_OrderId",
                table: "TransactionReports");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_PaymentId",
                table: "TransactionReports");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_ProductId",
                table: "TransactionReports");
        }
    }
}
