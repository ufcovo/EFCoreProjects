using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    // Product = Parent, ProductFeature = Child
    var category = _context.Categories.First(x => x.Name == "Eraser");
    var product = new Product { Name = "Eraser", Price = 200, Stock = 200, Barcode = 213, Category = category, ProductFeature = new() {
    Color = "Red", Height = 100, Width = 200} };

    _context.Products.Add(product);
    _context.SaveChanges();
    
    Console.WriteLine("Saved");
}