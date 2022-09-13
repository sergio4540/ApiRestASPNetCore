using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestNetCore.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransactionReports_OrderId",
                table: "TransactionReports",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionReports_ShoppingOrder_OrderId",
                table: "TransactionReports",
                column: "OrderId",
                principalTable: "ShoppingOrder",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionReports_ShoppingOrder_OrderId",
                table: "TransactionReports");

            migrationBuilder.DropIndex(
                name: "IX_TransactionReports_OrderId",
                table: "TransactionReports");
        }
    }
}
