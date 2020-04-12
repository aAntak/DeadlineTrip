using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Password" },
                values: new object[] { "Pirmas@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pirmaitis", "Pirmas", "test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Password" },
                values: new object[] { "Antras@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antraitis", "Antras", "test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Password" },
                values: new object[] { "Trecias@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trecaitis", "Trecias", "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AccountId",
                table: "Advertisements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Accounts_AccountId",
                table: "Advertisements",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Accounts_AccountId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AccountId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Advertisements");
        }
    }
}
