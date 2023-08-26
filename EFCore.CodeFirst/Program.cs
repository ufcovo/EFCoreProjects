using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    // Eager Loading
    //var category = new Category() { Name = "Pencils" };
    //category.Products.Add(new() { Name = "Pencil", Price = 100, Stock = 100, Barcode = 123, ProductFeature = new() { Color = "Blue", Height = 100, Width = 100 } });
    //category.Products.Add(new() { Name = "Pencil2", Price = 200, Stock = 200, Barcode = 124, ProductFeature = new() { Color = "Red", Height = 150, Width = 150 } });

    //await _context.AddAsync(category);

    //var categoryWithProducts = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).First();

    //await _context.SaveChangesAsync();

    //categoryWithProducts.Products.ForEach(r =>
    //{
    //    Console.WriteLine($"{categoryWithProducts.Name} {r.Name} {r.ProductFeature.Width}");
    //});


    //var productFeature = _context.productFeatures.Include(x => x.Product).ThenInclude(x => x.Category).First();

    //var product = _context.Products.Include(x => x.ProductFeature).Include(x => x.Category).First();

    // Explicit Loading
    //var category = _context.Categories.First();

    //if (true)
    //{
    //    _context.Entry(category).Collection(r => r.Products).Load();
    //    category.Products.ForEach(r =>
    //    {
    //        Console.WriteLine(r.Name);
    //    });
    //}

    //var product = _context.Products.First();
    //if (true)
    //{
    //    _context.Entry(product).Reference(t => t.ProductFeature).Load();
    //}

    // Lazy Loading

    var category = await _context.Categories.FirstAsync();

    var products = category.Products;

    foreach (var item in products)
    {
        // n + 1 problemi
        var productFeature = item.ProductFeature;
    }


    Console.WriteLine("Saved");
}