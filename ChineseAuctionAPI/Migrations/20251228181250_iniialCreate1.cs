using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class iniialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "GiftCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCategories", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsManager = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "winners",
                columns: table => new
                {
                    IdWinner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
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
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonor = table.Column<int>(type: "int", nullable: false),
                    DonorIdDonor = table.Column<int>(type: "int", nullable: false),
                    IsDrawn = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Gifts_GiftCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GiftCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
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
                    table.PrimaryKey("PK_Cards", x => x.IdCard);
                    table.ForeignKey(
                        name: "FK_Cards_Packages_PackageIdPackage",
                        column: x => x.PackageIdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "OrdersOrders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserIdUser = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsStatusDraft = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersOrders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_OrdersOrders_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersGift",
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
                    table.PrimaryKey("PK_OrdersGift", x => x.IdOrdersGift);
                    table.ForeignKey(
                        name: "FK_OrdersGift_Gifts_GiftIdGift",
                        column: x => x.GiftIdGift,
                        principalTable: "Gifts",
                        principalColumn: "IdGift",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersGift_OrdersOrders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "OrdersOrders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersPackage",
                columns: table => new
                {
                    IdPackageOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IdPackage = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtPurchase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPackage", x => x.IdPackageOrder);
                    table.ForeignKey(
                        name: "FK_OrdersPackage_OrdersOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrdersOrders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersPackage_Packages_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PackageIdPackage",
                table: "Cards",
                column: "PackageIdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserIdUser",
                table: "Cards",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_CategoryId",
                table: "Gifts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_GiftIdGift",
                table: "OrdersGift",
                column: "GiftIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_OrderIdOrder",
                table: "OrdersGift",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersOrders_IdUser",
                table: "OrdersOrders",
                column: "IdUser",
                unique: true,
                filter: "[IsStatusDraft] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersOrders_UserIdUser",
                table: "OrdersOrders",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPackage_IdPackage",
                table: "OrdersPackage",
                column: "IdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPackage_OrderId",
                table: "OrdersPackage",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "OrdersGift");

            migrationBuilder.DropTable(
                name: "OrdersPackage");

            migrationBuilder.DropTable(
                name: "winners");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "OrdersOrders");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "GiftCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
