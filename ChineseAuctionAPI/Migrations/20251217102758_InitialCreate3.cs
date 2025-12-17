using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Buyers_UserIdUser",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Buyers_BuyerIdUser",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Users_UserIdUser",
                table: "Card",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_BuyerIdUser",
                table: "Order",
                column: "BuyerIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Users_UserIdUser",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_BuyerIdUser",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Buyers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Buyers_UserIdUser",
                table: "Card",
                column: "UserIdUser",
                principalTable: "Buyers",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Buyers_BuyerIdUser",
                table: "Order",
                column: "BuyerIdUser",
                principalTable: "Buyers",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
