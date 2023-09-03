using AutoMapper.QueryableExtensions;
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using EFCore.CodeFirst.DTOs;
using EFCore.CodeFirst.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Xml.Linq;


Initializer.Build();

var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

IDbContextTransaction transaction = null;

using (var _context = new AppDbContext(connection))
{
    #region DataInsert
    //var category = new Category() { Name = "Pencils" };
    //category.Products.Add(new() { Name = "Pencil 1", Price = 100, Stock = 100, Barcode = 100, ProductFeature = new() { Color = "Red", Height = 100, Width = 100 } });
    //category.Products.Add(new() { Name = "Pencil 2", Price = 200, Stock = 200, Barcode = 200, ProductFeature = new() { Color = "Blue", Height = 200, Width = 200 } });
    //category.Products.Add(new() { Name = "Pencil 3", Price = 300, Stock = 300, Barcode = 300, ProductFeature = new() { Color = "Yellow", Height = 300, Width = 300 } });
    //category.Products.Add(new() { Name = "Pencil 4", Price = 400, Stock = 400, Barcode = 400 });

    //_context.Categories.Add(category);
    //_context.SaveChanges(); 
    #endregion

    using (transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Cips" };
        _context.Categories.Add(category);
        _context.SaveChanges();

        Product product = new()
        {
            Name = "Lays",
            Price = 100,
            Stock = 324,
            Barcode = 111,
            DiscountPrice = 1,
            CategoryId = category.Id,
        };

        _context.Products.Add(product);
        _context.SaveChanges();
        Console.WriteLine("using 1 Done");

        using (var dbContext2 = new AppDbContext(connection))
        {
            dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

            var product3 = dbContext2.Products.First();
            product3.Stock = 999;
            dbContext2.SaveChanges();
            Console.WriteLine("using 2 Done");
        }
        transaction.Commit();
    }
}






var _context = new AppDbContext(connection);
transaction = _context.Database.BeginTransaction();

var category = new Category() { Name = "Cips" };
_context.Categories.Add(category);
_context.SaveChanges();

Product product = new()
{
    Name = "Lays",
    Price = 100,
    Stock = 324,
    Barcode = 111,
    DiscountPrice = 1,
    CategoryId = category.Id,
};

_context.Products.Add(product);
_context.SaveChanges();
Console.WriteLine("using 1 Done");

var dbContext2 = new AppDbContext(connection);
dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

var product3 = dbContext2.Products.First();
product3.Stock = 999;
dbContext2.SaveChanges();
Console.WriteLine("using 2 Done");


transaction.Commit();

_context.Dispose();
dbContext2.Dispose();