using EFCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly int Barcode;

        // private readonly ITenantService tenantService

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }
        public AppDbContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(r => r.isDeleted).HasDefaultValue(false);
            if (Barcode != default(int))
                modelBuilder.Entity<Product>().HasQueryFilter(r => !r.isDeleted && r.Barcode == Barcode);
            else
                modelBuilder.Entity<Product>().HasQueryFilter(r => !r.isDeleted);
            base.OnModelCreating(modelBuilder);
        }
    }
}
