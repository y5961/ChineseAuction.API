using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Buyers_BuyerIdBuyer",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "IdBuyer",
                table: "winners",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "BuyerIdBuyer",
                table: "Order",
                newName: "BuyerIdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Order_BuyerIdBuyer",
                table: "Order",
                newName: "IX_Order_BuyerIdUser");

            migrationBuilder.RenameColumn(
                name: "IdBuyer",
                table: "Buyers",
                newName: "IdUser");

            migrationBuilder.AddColumn<bool>(
                name: "IsStatusDraft",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDrawn",
                table: "Gifts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsManager",
                table: "Buyers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    IdCard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGift = table.Column<int>(type: "int", nullable: false),
                    IdBuyer = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PackageIdPackage = table.Column<int>(type: "int", nullable: true),
                    UserIdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Card_Buyers_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Buyers",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_Card_Packages_PackageIdPackage",
                        column: x => x.PackageIdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_PackageIdPackage",
                table: "Card",
                column: "PackageIdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserIdUser",
                table: "Card",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Buyers_BuyerIdUser",
                table: "Order",
                column: "BuyerIdUser",
                principalTable: "Buyers",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Buyers_BuyerIdUser",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropColumn(
                name: "IsStatusDraft",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "IsDrawn",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Buyers");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "winners",
                newName: "IdBuyer");

            migrationBuilder.RenameColumn(
                name: "BuyerIdUser",
                table: "Order",
                newName: "BuyerIdBuyer");

            migrationBuilder.RenameIndex(
                name: "IX_Order_BuyerIdUser",
                table: "Order",
                newName: "IX_Order_BuyerIdBuyer");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Buyers",
                newName: "IdBuyer");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Buyers_BuyerIdBuyer",
                table: "Order",
                column: "BuyerIdBuyer",
                principalTable: "Buyers",
                principalColumn: "IdBuyer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
