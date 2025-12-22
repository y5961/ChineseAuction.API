using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Packages_PackageIdPackage",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Users_UserIdUser",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Packages_PackageIdPackage",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_BuyerIdUser",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_OrderIdOrder",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BuyerIdUser",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "BuyerIdUser",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdBuyer",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrdersOrders");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "cards");

            migrationBuilder.RenameColumn(
                name: "PackageIdPackage",
                table: "OrdersOrders",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "IdPackage",
                table: "OrdersOrders",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PackageIdPackage",
                table: "OrdersOrders",
                newName: "IX_OrdersOrders_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Card_UserIdUser",
                table: "cards",
                newName: "IX_cards_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PackageIdPackage",
                table: "cards",
                newName: "IX_cards_PackageIdPackage");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderIdOrder",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersOrders",
                table: "OrdersOrders",
                column: "IdOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cards",
                table: "cards",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_OrderIdOrder",
                table: "Packages",
                column: "OrderIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_Packages_PackageIdPackage",
                table: "cards",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_Users_UserIdUser",
                table: "cards",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersOrders_OrderIdOrder",
                table: "Orders",
                column: "OrderIdOrder",
                principalTable: "OrdersOrders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersOrders_Users_UserIdUser",
                table: "OrdersOrders",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_OrdersOrders_OrderIdOrder",
                table: "Packages",
                column: "OrderIdOrder",
                principalTable: "OrdersOrders",
                principalColumn: "IdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_Packages_PackageIdPackage",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_cards_Users_UserIdUser",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersOrders_OrderIdOrder",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersOrders_Users_UserIdUser",
                table: "OrdersOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_OrdersOrders_OrderIdOrder",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Packages_OrderIdOrder",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersOrders",
                table: "OrdersOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cards",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderIdOrder",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "OrdersOrders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "cards",
                newName: "Card");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Order",
                newName: "PackageIdPackage");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Order",
                newName: "IdPackage");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersOrders_UserIdUser",
                table: "Order",
                newName: "IX_Order_PackageIdPackage");

            migrationBuilder.RenameIndex(
                name: "IX_cards_UserIdUser",
                table: "Card",
                newName: "IX_Card_UserIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_cards_PackageIdPackage",
                table: "Card",
                newName: "IX_Card_PackageIdPackage");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerIdUser",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBuyer",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "IdOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerIdUser",
                table: "Order",
                column: "BuyerIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Packages_PackageIdPackage",
                table: "Card",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Users_UserIdUser",
                table: "Card",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Packages_PackageIdPackage",
                table: "Order",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_BuyerIdUser",
                table: "Order",
                column: "BuyerIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_OrderIdOrder",
                table: "Orders",
                column: "OrderIdOrder",
                principalTable: "Order",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
