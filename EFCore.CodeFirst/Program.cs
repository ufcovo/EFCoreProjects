using EFCore.CodeFirst;
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


    // create procedure sp_insert_products
    // @name nvarchar(max),
    // @price decimal(9, 2),
    // @discount decimal(9, 2),
    // @stock int,
    // @barcode int,
    //     @categoryId int,
    //     @newId int output

    // as
    //     begin
    // insert into Products(Name, Price, DiscountPrice, Stock, Barcode, CategoryId)
    // values
    // (@name, @price, @discount, @stock, @barcode, @categoryId)
    // set @newId = SCOPE_IDENTITY();
    //     return @newId
    // end


    // declare @newId int;
    // exec sp_insert_products 'Pencil 1000', 1000, 1000, 1000, 1000, 1, @newId output
    // select @newId

    var product = new Product()
    {
        Name = "Pencil 2000",
        Price = 2000,
        DiscountPrice = 2000,
        Stock = 2000,
        Barcode = 2000,
        CategoryId = 1
    };

    var newProductIdParameter = new SqlParameter("@newId", System.Data.SqlDbType.Int);
    newProductIdParameter.Direction = System.Data.ParameterDirection.Output;

    _context.Database.ExecuteSqlInterpolated($"exec sp_insert_products {product.Name}, {product.Price}, {product.DiscountPrice}, {product.Stock}, {product.Barcode}, {product.CategoryId}, {newProductIdParameter} out");

    var newProductId = newProductIdParameter.Value;



    // create procedure sp_insert_products_noReturn
    // @name nvarchar(max),
    // @price decimal(9, 2),
    // @discount decimal(9, 2),
    // @stock int,
    // @barcode int,
    // @categoryId int

    // as
    // begin
    // insert into Products(Name, Price, DiscountPrice, Stock, Barcode, CategoryId)
    // values
    // (@name, @price, @discount, @stock, @barcode, @categoryId)

    // end


    // exec sp_insert_products_noReturn 'Pencil 2000', 2000, 2000, 2000, 2000, 1

    var product2 = new Product()
    {
        Name = "Pencil 4000",
        Price = 4000,
        DiscountPrice = 4000,
        Stock = 4000,
        Barcode = 4000,
        CategoryId = 1
    };

    _context.Database.ExecuteSqlInterpolated($"exec sp_insert_products_noReturn {product2.Name}, {product2.Price}, {product2.DiscountPrice}, {product2.Stock}, {product2.Barcode}, {product2.CategoryId}");




    Console.WriteLine();
}