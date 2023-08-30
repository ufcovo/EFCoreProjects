using EFCore.CodeFirst;
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


    var resultLeftJoin = await (from p in _context.Products
                                join pf in _context.ProductFeatures on p.Id equals pf.Id into pfList
                                from pf in pfList.DefaultIfEmpty()
                                select new
                                {
                                    ProductName = p.Name,
                                    Color = pf.Color,
                                    Width = (int?)pf.Width
                                }).ToListAsync();

    var resultRightJoin = await (from pf in _context.ProductFeatures
                                 join p in _context.Products on pf.Id equals p.Id into pList
                                 from p in pList.DefaultIfEmpty()
                                 select new
                                 {
                                     ProductName = p.Name,
                                     ProductPrice = (decimal?)p.Price,
                                     Color = pf.Color,
                                     Width = (int?)pf.Width
                                 }).ToListAsync();


    Console.WriteLine("");
}