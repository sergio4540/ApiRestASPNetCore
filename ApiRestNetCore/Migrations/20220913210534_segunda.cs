using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestNetCore.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Payment",
                newName: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ClienteId",
                table: "Payment",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customer_ClienteId",
                table: "Payment",
                column: "ClienteId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customer_ClienteId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ClienteId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Payment",
                newName: "CategoryId");
        }
    }
}
