﻿using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
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



    // create function fc_product_full_parameter(@categoryId int)
    // RETURNS TABLE
    // as
    // RETURN (
    // select p.Id, p.Name, pf.Width, pf.Height from Products as p
    // left join ProductFeatures as pf on p.Id = pf.Id
    // where p.CategoryId = @categoryId
    // )

    // select* from fc_product_full_parameter(1)

    int categoryId = 1;
    var products = await _context.GetProductWithFeatures(categoryId).ToListAsync();
    
    Console.WriteLine();
}