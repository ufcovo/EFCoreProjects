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


    // Join of two table
    var result = _context.Categories.Join(_context.Products, r => r.Id, x => x.CategoryId, (c, p) => new
    {
        CategoryName = c.Name,
        ProductName = p.Name,
        ProductPrice = p.Price
    }).ToList();

    var resultProduct = _context.Categories.Join(_context.Products, r => r.Id, x => x.CategoryId, (c, p) => p).ToList();
    var resultCategory = _context.Categories.Join(_context.Products, r => r.Id, x => x.CategoryId, (c, p) => c).ToList();

    var result2 = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   select new
                   {
                       CategoryName = c.Name,
                       ProductName = p.Name,
                       ProductPrice = p.Price
                   }).ToList();

    var result2Product = (from c in _context.Categories
                          join p in _context.Products on c.Id equals p.CategoryId
                          select p).ToList();


    // Join of three table

    var result3 = _context.Categories
        .Join(_context.Products, r => r.Id, x => x.CategoryId, (c, p) => new { c, p })
        .Join(_context.ProductFeatures, x => x.p.Id, y => y.Id, (c, pf) => new
        {
            CategoryName = c.c.Name,
            ProductName = c.p.Name,
            ProductPrice = c.p.Price,
            ProductColor = pf.Color
        }).ToList();

    var result4 = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   join pf in _context.ProductFeatures on p.Id equals pf.Id
                   select new
                   {
                       CategoryName = c.Name,
                       ProductName = p.Name,
                       ProductPrice = p.Price,
                       ProductColor = pf.Color
                   }).ToList();

    var result5 = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   join pf in _context.ProductFeatures on p.Id equals pf.Id
                   select new { c, p, pf }).ToList();

    Console.WriteLine("");
}