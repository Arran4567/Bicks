using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Enums;

namespace Bicks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Link DB Table to Model
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Site>().ToTable("Sites");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Site> Sites { get; set; }

        private void seedProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Streaky Bacon",
                    PricePerKg = 5.40m
                },
                new Product
                {
                    ID = 2,
                    Name = "Black Pudding",
                    PricePerKg = 2.60m
                },
                new Product
                {
                    ID = 3,
                    Name = "Strip Loin",
                    PricePerKg = 19.50m
                }
            );
        }
    }
}
