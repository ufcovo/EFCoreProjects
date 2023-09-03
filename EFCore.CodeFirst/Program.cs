using AutoMapper.QueryableExtensions;
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using EFCore.CodeFirst.DTOs;
using EFCore.CodeFirst.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

Initializer.Build();

using (var _context = new AppDbContext())
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

    // Use the try catch block if there is log insertion. Otherwise, it is not necessary or if nothing special is done in the catch block.
    // if there is catch blok, must use transaction.RollBack()
    using (var transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Games" };
        _context.Categories.Add(category);
        _context.SaveChanges();

        Product product = new()
        {
            Name = "GOW",
            Price = 100,
            Stock = 324,
            Barcode = 111,
            DiscountPrice = 1,
            CategoryId = category.Id,
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        transaction.Commit();

        Console.WriteLine("Done");
    }


        
}