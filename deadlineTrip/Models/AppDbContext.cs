using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class AppDbContext : DbContext
    {
        // Dbcontext turi tureti dbcontext opts

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //which entities it will manage

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<AuctionBet> AuctionBets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Card>().HasData();


            //seed categories
            modelBuilder.Entity<Card>().HasData(new Card { Id = 1, Name = "Predaplant Verte Anaconda", Image = "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442543.jpg", Attack = 25, Defense = 42, Level = 3 });
            modelBuilder.Entity<Card>().HasData(new Card { Id = 2, Name = "PSY-Framelord Omega", Image = "https://static.cardmarket.com/img/9274d1a282a820759dbbf43d35d14a4d/items/5/DUOV/442843.jpg", Attack = 42, Defense = 100, Level = 1 });
            modelBuilder.Entity<Card>().HasData(new Card { Id = 3, Name = "Bebru valdovas", Image = "https://lh3.googleusercontent.com/proxy/vBhKwbhLVflNslii0Ycy2El2BrErJbRL9Chck3w_BIK9UYlhD1JsH8uk_EMEHjZJIc33qZHRJxSMsPR8BvxLSzNLlQ10mAoO4wMvi9qH_-o1JImao2JXYQDGy7cEC52Pc6lYbmnaBVL6Isab_XdrVKYaNxgUElngFYc6Wud8NlACspGwp4wpyf6_yu2TDTI_wwDEAjgba4akf9o85t_P207cWkU", Attack = 9999, Defense = 9999, Level = 99 });


            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 1, Price = 46, Quantity = 46, AccountId = "Pirmas@gmail.com", CardId = 1 });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 2, Price = 52, Quantity = 46, AccountId = "Pirmas@gmail.com", CardId = 2 });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 3, Price = 14, Quantity = 46, AccountId = "Trecias@gmail.com", CardId = 3 });

            Account First = new Account { Id = "Pirmas@gmail.com", Name = "Pirmas", LastName = "Pirmaitis", Password = "test", BirthDate = new DateTime(2015, 12, 25) };
            Account Second = new Account { Id = "Antras@gmail.com", Name = "Antras", LastName = "Antraitis", Password = "test", BirthDate = new DateTime(2015, 12, 25) };
            Account Third = new Account { Id = "Trecias@gmail.com", Name = "Trecias", LastName = "Trecaitis", Password = "test", BirthDate = new DateTime(2015, 12, 25) };

            modelBuilder.Entity<Account>().HasData(First);
            modelBuilder.Entity<Account>().HasData(Second);
            modelBuilder.Entity<Account>().HasData(Third);

            modelBuilder.Entity<Advertisement>().
                HasOne(x => x.Auction).
                WithOne(x => x.Advertisement).
                HasForeignKey<Auction>(x => x.AdvertisementId);

            modelBuilder.Entity<Auction>()
                .HasMany(x => x.Bets)
                .WithOne(x => x.Auction);

        }




    }
}
