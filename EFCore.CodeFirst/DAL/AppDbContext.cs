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
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> productFeatures { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Ignore(r => r.Barcode);
            modelBuilder.Entity<Product>().Property(r => r.Name).IsUnicode(false);
            modelBuilder.Entity<Product>().Property(r => r.Url).HasColumnType("varchar(500)").HasColumnName("ProductUrl");
            base.OnModelCreating(modelBuilder);
        }
    }
}
