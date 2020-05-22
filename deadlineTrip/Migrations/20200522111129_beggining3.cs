using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class beggining3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vote_type",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Price is good" });

            migrationBuilder.InsertData(
                table: "Vote_type",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Price is too low" });

            migrationBuilder.InsertData(
                table: "Vote_type",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Price is too big" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vote_type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vote_type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vote_type",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
