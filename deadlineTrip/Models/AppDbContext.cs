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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 1, Price = 46, Quantity = 46 });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 2, Price = 52, Quantity = 46 });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement { Id = 3, Price = 14, Quantity = 46 });
        }

            


    }
}
