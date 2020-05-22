using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class beggining6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Card_CardId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Game",
                table: "Card");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Advertisements_CardId",
                table: "Game",
                column: "CardId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Advertisements_CardId",
                table: "Game");

            migrationBuilder.AddColumn<bool>(
                name: "Game",
                table: "Card",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Card_CardId",
                table: "Game",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
