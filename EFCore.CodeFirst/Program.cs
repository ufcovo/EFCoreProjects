﻿using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //var category = new Category() { Name = "Pencils" };
    //category.Products.Add(new() { Name = "Pencil 1", Price = 100, Stock = 100, Barcode = 100, ProductFeature = new() { Color = "Red", Height = 100, Width = 100 } });
    //category.Products.Add(new() { Name = "Pencil 2", Price = 200, Stock = 200, Barcode = 200, ProductFeature = new() { Color = "Blue", Height = 200, Width = 200 } });
    //category.Products.Add(new() { Name = "Pencil 3", Price = 300, Stock = 300, Barcode = 300, ProductFeature = new() { Color = "Yellow", Height = 300, Width = 300 } });
    //category.Products.Add(new() { Name = "Pencil 4", Price = 400, Stock = 400, Barcode = 400 });

    //_context.Categories.Add(category);
    //_context.SaveChanges();

    var products = await _context.Products.FromSqlRaw("select * from Products").ToListAsync();

    var Id = 4;
    var products2 = await _context.Products.FromSqlRaw("select * from Products where id={0}", Id).FirstAsync();

    decimal price = 300;
    var products3 = await _context.Products.FromSqlRaw("select * from Products where price > {0}", price).ToListAsync();


    var products4 = await _context.Products.FromSqlInterpolated($"select * from Products where price > {price}").ToListAsync();

    Console.WriteLine("");
}