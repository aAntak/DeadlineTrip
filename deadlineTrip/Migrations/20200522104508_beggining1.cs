using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class beggining1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Retumas_Retumasid",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Retumas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pav",
                table: "Retumas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Retumasid",
                table: "Card",
                newName: "RetumasId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_Retumasid",
                table: "Card",
                newName: "IX_Card_RetumasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Retumas_RetumasId",
                table: "Card",
                column: "RetumasId",
                principalTable: "Retumas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Retumas_RetumasId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Retumas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Retumas",
                newName: "pav");

            migrationBuilder.RenameColumn(
                name: "RetumasId",
                table: "Card",
                newName: "Retumasid");

            migrationBuilder.RenameIndex(
                name: "IX_Card_RetumasId",
                table: "Card",
                newName: "IX_Card_Retumasid");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Retumas_Retumasid",
                table: "Card",
                column: "Retumasid",
                principalTable: "Retumas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
