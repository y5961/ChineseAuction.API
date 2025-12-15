using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialsCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    IdBuyer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.IdBuyer);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    IdDonor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.IdDonor);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    IdPackage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountRegular = table.Column<int>(type: "int", nullable: false),
                    AmountPremium = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.IdPackage);
                });

            migrationBuilder.CreateTable(
                name: "winners",
                columns: table => new
                {
                    IdWinner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBuyer = table.Column<int>(type: "int", nullable: false),
                    IdGift = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_winners", x => x.IdWinner);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    IdGift = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonor = table.Column<int>(type: "int", nullable: false),
                    DonorIdDonor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.IdGift);
                    table.ForeignKey(
                        name: "FK_Gifts_Donors_DonorIdDonor",
                        column: x => x.DonorIdDonor,
                        principalTable: "Donors",
                        principalColumn: "IdDonor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBuyer = table.Column<int>(type: "int", nullable: false),
                    BuyerIdBuyer = table.Column<int>(type: "int", nullable: false),
                    IdPackage = table.Column<int>(type: "int", nullable: false),
                    PackageIdPackage = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Buyers_BuyerIdBuyer",
                        column: x => x.BuyerIdBuyer,
                        principalTable: "Buyers",
                        principalColumn: "IdBuyer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Packages_PackageIdPackage",
                        column: x => x.PackageIdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrdersGift = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGift = table.Column<int>(type: "int", nullable: false),
                    GiftIdGift = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    OrderIdOrder = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrdersGift);
                    table.ForeignKey(
                        name: "FK_Orders_Gifts_GiftIdGift",
                        column: x => x.GiftIdGift,
                        principalTable: "Gifts",
                        principalColumn: "IdGift",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Order_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerIdBuyer",
                table: "Order",
                column: "BuyerIdBuyer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PackageIdPackage",
                table: "Order",
                column: "PackageIdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftIdGift",
                table: "Orders",
                column: "GiftIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderIdOrder",
                table: "Orders",
                column: "OrderIdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "winners");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
