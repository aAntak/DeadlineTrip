﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using deadlineTrip.Models;

namespace deadlineTrip.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("CardId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CardId");

                    b.ToTable("Advertisements");

                    b.HasData(
                        new { Id = 1, AccountId = "Pirmas@gmail.com", Price = 46m, Quantity = 46 },
                        new { Id = 2, AccountId = "Pirmas@gmail.com", Price = 52m, Quantity = 46 },
                        new { Id = 3, AccountId = "Trecias@gmail.com", Price = 14m, Quantity = 46 }
                    );
                });

            modelBuilder.Entity("deadlineTrip.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack");

                    b.Property<int>("Defense");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("Retumasid");

                    b.HasKey("Id");

                    b.HasIndex("Retumasid");

                    b.ToTable("Card");
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

            modelBuilder.Entity("deadlineTrip.Models.Advertisement", b =>
                {
                    b.HasOne("deadlineTrip.Models.Account")
                        .WithMany("Advertisements")
                        .HasForeignKey("AccountId");

                    b.HasOne("deadlineTrip.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId");
                });

            modelBuilder.Entity("deadlineTrip.Models.Card", b =>
                {
                    b.HasOne("deadlineTrip.Models.Retumas", "Retumas")
                        .WithMany()
                        .HasForeignKey("Retumasid");
                });
#pragma warning restore 612, 618
        }
    }
}
