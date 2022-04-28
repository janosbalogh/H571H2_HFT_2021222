using H571H2_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace H571H2_HFT_2021222.Repository
{
    public class SteamDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Person> People { get; set; }

        public SteamDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("SteamDb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(game => game.Company)
                .WithMany(game => game.Game)
                .HasForeignKey(game => game.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>()
                .HasOne(company => company.Executive)
                .WithOne(company => company.Company)
                .HasForeignKey<Person>(company => company.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);


            //Db Seed

            modelBuilder.Entity<Company>().HasData(new Company[]
            {
                

            });
            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                


            });
            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                
            });


        }





    }
}
