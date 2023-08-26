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
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> productFeatures{ get; set; }
        public DbSet<BasePerson> Person { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Employee> Employee { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            // one to one
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(X => X.ProductRef_Id);

            // many to many
            //modelBuilder.Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "StudentTeacherManyToMany",
            //        x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id")
            //        .HasConstraintName("FK_TeacherId"),
            //        x => x.HasOne<Student>().WithMany().HasForeignKey("Student_Id")
            //        .HasConstraintName("FK_StudentID")
            //    ); 

            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(
            //    x => x.CategoryId).OnDelete(deleteBehavior: DeleteBehavior.SetNull);

            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAdd(); // identity
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAddOrUpdate(); // computed
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedNever(); // none

            //modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);

            // TPT
            modelBuilder.Entity<BasePerson>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Emplooyes");
            modelBuilder.Entity<Manager>().ToTable("Managers");
            base.OnModelCreating(modelBuilder);
        }
    }
}
