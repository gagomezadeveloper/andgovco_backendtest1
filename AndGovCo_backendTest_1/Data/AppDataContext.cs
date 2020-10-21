using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AndGovCo_backendTest_1.Models;

namespace AndGovCo_backendTest_1.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductState> ProductStates { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductState>().ToTable("ProductState");
            modelBuilder.Entity<ProductType>().ToTable("ProductoType");            
        }
    }
}