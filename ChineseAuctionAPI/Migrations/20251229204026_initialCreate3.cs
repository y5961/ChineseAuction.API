using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersGift_Gifts_GiftIdGift",
                table: "OrdersGift");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersGift_OrdersOrders_OrderIdOrder",
                table: "OrdersGift");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersOrders_Users_UserIdUser",
                table: "OrdersOrders");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OrdersOrders_UserIdUser",
                table: "OrdersOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrdersGift_GiftIdGift",
                table: "OrdersGift");

            migrationBuilder.DropIndex(
                name: "IX_OrdersGift_OrderIdOrder",
                table: "OrdersGift");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "OrdersOrders");

            migrationBuilder.DropColumn(
                name: "GiftIdGift",
                table: "OrdersGift");

            migrationBuilder.DropColumn(
                name: "OrderIdOrder",
                table: "OrdersGift");

            migrationBuilder.DropColumn(
                name: "DonorIdDonor",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GiftCategories",
                newName: "IdGiftCategory");

            migrationBuilder.RenameColumn(
                name: "IdBuyer",
                table: "Cards",
                newName: "IdUser");

            migrationBuilder.AlterColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Packages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Gifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_winners_IdGift",
                table: "winners",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_winners_IdUser",
                table: "winners",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_IdGift",
                table: "OrdersGift",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_IdOrder",
                table: "OrdersGift",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_IdDonor",
                table: "Gifts",
                column: "IdDonor");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_IdUser",
                table: "Gifts",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_IdDonor",
                table: "Gifts",
                column: "IdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Users_IdUser",
                table: "Gifts",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersGift_Gifts_IdGift",
                table: "OrdersGift",
                column: "IdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersGift_OrdersOrders_IdOrder",
                table: "OrdersGift",
                column: "IdOrder",
                principalTable: "OrdersOrders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersOrders_Users_IdUser",
                table: "OrdersOrders",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_winners_Gifts_IdGift",
                table: "winners",
                column: "IdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_winners_Users_IdUser",
                table: "winners",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_IdDonor",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Users_IdUser",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersGift_Gifts_IdGift",
                table: "OrdersGift");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersGift_OrdersOrders_IdOrder",
                table: "OrdersGift");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersOrders_Users_IdUser",
                table: "OrdersOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_winners_Gifts_IdGift",
                table: "winners");

            migrationBuilder.DropForeignKey(
                name: "FK_winners_Users_IdUser",
                table: "winners");

            migrationBuilder.DropIndex(
                name: "IX_winners_IdGift",
                table: "winners");

            migrationBuilder.DropIndex(
                name: "IX_winners_IdUser",
                table: "winners");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OrdersGift_IdGift",
                table: "OrdersGift");

            migrationBuilder.DropIndex(
                name: "IX_OrdersGift_IdOrder",
                table: "OrdersGift");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_IdDonor",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_IdUser",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "IdGiftCategory",
                table: "GiftCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Cards",
                newName: "IdBuyer");

            migrationBuilder.AlterColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "OrdersOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GiftIdGift",
                table: "OrdersGift",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderIdOrder",
                table: "OrdersGift",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonorIdDonor",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersOrders_UserIdUser",
                table: "OrdersOrders",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_GiftIdGift",
                table: "OrdersGift",
                column: "GiftIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersGift_OrderIdOrder",
                table: "OrdersGift",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersGift_Gifts_GiftIdGift",
                table: "OrdersGift",
                column: "GiftIdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersGift_OrdersOrders_OrderIdOrder",
                table: "OrdersGift",
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
        }
    }
}
