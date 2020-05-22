using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class onemore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameVote_Vote_type_Vote_typeId",
                table: "GameVote");

            migrationBuilder.DropIndex(
                name: "IX_GameVote_Vote_typeId",
                table: "GameVote");

            migrationBuilder.DropColumn(
                name: "Vote_typeId",
                table: "GameVote");

            migrationBuilder.AddColumn<int>(
                name: "Vote_type",
                table: "GameVote",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vote_type",
                table: "GameVote");

            migrationBuilder.AddColumn<int>(
                name: "Vote_typeId",
                table: "GameVote",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameVote_Vote_typeId",
                table: "GameVote",
                column: "Vote_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameVote_Vote_type_Vote_typeId",
                table: "GameVote",
                column: "Vote_typeId",
                principalTable: "Vote_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
