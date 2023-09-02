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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductCount> productCounts { get; set; }


        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId) => FromExpression(() => GetProductWithFeatures(categoryId));

        public int GetProductCount(int categoryId)
        {
            throw new NotSupportedException("You cannot call this function directly from ef core.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).
                UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"))
                .UseQueryTrackingBehavior(queryTrackingBehavior: QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] { typeof(int)})!).HasName("fc_product_full_parameter");
            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!).HasName("fc_get_product_count");

            modelBuilder.Entity<ProductCount>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
