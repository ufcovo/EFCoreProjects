using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

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


    // create procedure sp_get_products_full
    // as
    // begin
    // select p.Id, p.Name, p.Price, c.Name 'CategoryName', pf.Width, pf.Height from Products as p
    // join Categories as c on p.CategoryId = c.Id
    // join ProductFeatures as pf on p.Id = pf.Id
    // end


    var products = _context.ProductFulls.FromSqlRaw("exec sp_get_products_full").ToList();
    products = products.Where(p => p.Width > 100).ToList();

    Console.WriteLine();
}