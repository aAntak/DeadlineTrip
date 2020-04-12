using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { "Pirmas@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pirmaitis", "Pirmas", "test" },
                    { "Antras@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antraitis", "Antras", "test" },
                    { "Trecias@gmail.com", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trecaitis", "Trecias", "test" }
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "Attack", "Defense", "Image", "Level", "Name", "Retumasid" },
                values: new object[,]
                {
                    { 1, 25, 42, "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442543.jpg", 3, "Predaplant Verte Anaconda", null },
                    { 2, 42, 100, "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442843.jpg", 1, "PSY-Framelord Omega", null },
                    { 3, 9999, 9999, "https://lh3.googleusercontent.com/proxy/vBhKwbhLVflNslii0Ycy2El2BrErJbRL9Chck3w_BIK9UYlhD1JsH8uk_EMEHjZJIc33qZHRJxSMsPR8BvxLSzNLlQ10mAoO4wMvi9qH_-o1JImao2JXYQDGy7cEC52Pc6lYbmnaBVL6Isab_XdrVKYaNxgUElngFYc6Wud8NlACspGwp4wpyf6_yu2TDTI_wwDEAjgba4akf9o85t_P207cWkU", 99, "Bebru valdovas", null }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "Price", "Quantity" },
                values: new object[] { 1, "Pirmas@gmail.com", 1, 46m, 46 });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "Price", "Quantity" },
                values: new object[] { 2, "Pirmas@gmail.com", 2, 52m, 46 });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "Price", "Quantity" },
                values: new object[] { 3, "Trecias@gmail.com", 3, 14m, 46 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "Antras@gmail.com");

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "Pirmas@gmail.com");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "Trecias@gmail.com");

            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
