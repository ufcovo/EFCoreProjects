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
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(r => r.Name);
            modelBuilder.Entity<Product>().HasIndex(r => r.Price);

            modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountCheck","[Price] > [Discount]");

            //modelBuilder.Entity<Product>().HasIndex(r => r.Price).IncludeProperties(r => new { r.Name, r.Url });
            //modelBuilder.Entity<Product>().HasIndex(r => new { r.Price, r.Url });
            base.OnModelCreating(modelBuilder);
        }
    }
}
