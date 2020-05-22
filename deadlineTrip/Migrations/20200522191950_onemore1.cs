using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace deadlineTrip.Migrations
{
    public partial class onemore1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Retumas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retumas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vote_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    accountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    RetumasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Retumas_RetumasId",
                        column: x => x.RetumasId,
                        principalTable: "Retumas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: false),
                    IsInGame = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisements_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartingPrice = table.Column<double>(nullable: false),
                    BuyNowPrice = table.Column<double>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    WinnerEmail = table.Column<string>(nullable: true),
                    FinalPrice = table.Column<double>(nullable: true),
                    AdvertisementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(nullable: false),
                    GameVote = table.Column<int>(nullable: false),
                    MaxVoteCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Advertisements_CardId",
                        column: x => x.CardId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    adId = table.Column<int>(nullable: false),
                    ShoppingCartId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId1",
                        column: x => x.ShoppingCartId1,
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Advertisements_adId",
                        column: x => x.adId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Vote_typeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameVote_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameVote_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameVote_Vote_type_Vote_typeId",
                        column: x => x.Vote_typeId,
                        principalTable: "Vote_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "Id", "Attack", "Defense", "Image", "Level", "Name", "RetumasId" },
                values: new object[,]
                {
                    { 1, 25, 42, "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442543.jpg", 3, "Predaplant Verte Anaconda", null },
                    { 2, 42, 100, "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442843.jpg", 1, "PSY-Framelord Omega", null },
                    { 3, 9999, 9999, "https://lh3.googleusercontent.com/proxy/vBhKwbhLVflNslii0Ycy2El2BrErJbRL9Chck3w_BIK9UYlhD1JsH8uk_EMEHjZJIc33qZHRJxSMsPR8BvxLSzNLlQ10mAoO4wMvi9qH_-o1JImao2JXYQDGy7cEC52Pc6lYbmnaBVL6Isab_XdrVKYaNxgUElngFYc6Wud8NlACspGwp4wpyf6_yu2TDTI_wwDEAjgba4akf9o85t_P207cWkU", 99, "Bebru valdovas", null }
                });

            migrationBuilder.InsertData(
                table: "Vote_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Price is good" },
                    { 2, "Price is too low" },
                    { 3, "Price is too big" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "IsInGame", "Price", "Quantity" },
                values: new object[] { 1, "Pirmas@gmail.com", 1, false, 46m, 46 });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "IsInGame", "Price", "Quantity" },
                values: new object[] { 2, "Pirmas@gmail.com", 2, false, 52m, 46 });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AccountId", "CardId", "IsInGame", "Price", "Quantity" },
                values: new object[] { 3, "Trecias@gmail.com", 3, false, 14m, 46 });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AccountId",
                table: "Advertisements",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CardId",
                table: "Advertisements",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_AdvertisementId",
                table: "Auctions",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_RetumasId",
                table: "Card",
                column: "RetumasId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_CardId",
                table: "Game",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVote_GameId",
                table: "GameVote",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVote_UserId",
                table: "GameVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameVote_Vote_typeId",
                table: "GameVote",
                column: "Vote_typeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_accountId",
                table: "ShoppingCart",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId1",
                table: "ShoppingCartItem",
                column: "ShoppingCartId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_adId",
                table: "ShoppingCartItem",
                column: "adId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "GameVote");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Vote_type");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Retumas");
        }
    }
}
