﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using deadlineTrip.Models;

namespace deadlineTrip.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200520122430_auction")]
    partial class auction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("deadlineTrip.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new { Id = "Pirmas@gmail.com", BirthDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), LastName = "Pirmaitis", Name = "Pirmas", Password = "test" },
                        new { Id = "Antras@gmail.com", BirthDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), LastName = "Antraitis", Name = "Antras", Password = "test" },
                        new { Id = "Trecias@gmail.com", BirthDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), LastName = "Trecaitis", Name = "Trecias", Password = "test" }
                    );
                });

            modelBuilder.Entity("deadlineTrip.Models.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountId");

                    b.Property<int>("CardId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CardId");

                    b.ToTable("Advertisements");

                    b.HasData(
                        new { Id = 1, AccountId = "Pirmas@gmail.com", CardId = 1, Price = 46m, Quantity = 46 },
                        new { Id = 2, AccountId = "Pirmas@gmail.com", CardId = 2, Price = 52m, Quantity = 46 },
                        new { Id = 3, AccountId = "Trecias@gmail.com", CardId = 3, Price = 14m, Quantity = 46 }
                    );
                });

            modelBuilder.Entity("deadlineTrip.Models.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertisementId");

                    b.Property<double>("BuyNowPrice");

                    b.Property<DateTime>("EndDate");

                    b.Property<double?>("FinalPrice");

                    b.Property<double>("StartingPrice");

                    b.Property<string>("WinnerEmail");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("deadlineTrip.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack");

                    b.Property<int>("Defense");

                    b.Property<string>("Image");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("Retumasid");

                    b.HasKey("Id");

                    b.HasIndex("Retumasid");

                    b.ToTable("Card");

                    b.HasData(
                        new { Id = 1, Attack = 25, Defense = 42, Image = "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442543.jpg", Level = 3, Name = "Predaplant Verte Anaconda" },
                        new { Id = 2, Attack = 42, Defense = 100, Image = "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442843.jpg", Level = 1, Name = "PSY-Framelord Omega" },
                        new { Id = 3, Attack = 9999, Defense = 9999, Image = "https://lh3.googleusercontent.com/proxy/vBhKwbhLVflNslii0Ycy2El2BrErJbRL9Chck3w_BIK9UYlhD1JsH8uk_EMEHjZJIc33qZHRJxSMsPR8BvxLSzNLlQ10mAoO4wMvi9qH_-o1JImao2JXYQDGy7cEC52Pc6lYbmnaBVL6Isab_XdrVKYaNxgUElngFYc6Wud8NlACspGwp4wpyf6_yu2TDTI_wwDEAjgba4akf9o85t_P207cWkU", Level = 99, Name = "Bebru valdovas" }
                    );
                });

            modelBuilder.Entity("deadlineTrip.Models.Retumas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("pav");

                    b.HasKey("id");

                    b.ToTable("Retumas");
                });

            modelBuilder.Entity("deadlineTrip.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accountId");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("accountId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("deadlineTrip.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ShoppingCartId1");

                    b.Property<int>("adId");

                    b.Property<int>("quantity");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ShoppingCartId1");

                    b.HasIndex("adId");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("deadlineTrip.Models.Advertisement", b =>
                {
                    b.HasOne("deadlineTrip.Models.Account")
                        .WithMany("Advertisements")
                        .HasForeignKey("AccountId");

                    b.HasOne("deadlineTrip.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("deadlineTrip.Models.Auction", b =>
                {
                    b.HasOne("deadlineTrip.Models.Advertisement", "Advertisement")
                        .WithOne("Auction")
                        .HasForeignKey("deadlineTrip.Models.Auction", "AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("deadlineTrip.Models.Card", b =>
                {
                    b.HasOne("deadlineTrip.Models.Retumas", "Retumas")
                        .WithMany()
                        .HasForeignKey("Retumasid");
                });

            modelBuilder.Entity("deadlineTrip.Models.ShoppingCart", b =>
                {
                    b.HasOne("deadlineTrip.Models.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountId");
                });

            modelBuilder.Entity("deadlineTrip.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("deadlineTrip.Models.ShoppingCart", "ShoppingCartId")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId1");

                    b.HasOne("deadlineTrip.Models.Advertisement", "ad")
                        .WithMany()
                        .HasForeignKey("adId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
