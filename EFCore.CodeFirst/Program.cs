using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = new Category() { Name = "Pencils" };
    var product = new Product() { Name = "Pencil 1", Price = 100, Stock = 100, Barcode = 123, Category = category };

    //_context.Categories.Add(category); Buna gerek yok. Navigation property den direkt olarak eklenmekte.
    _context.Products.Add(product);
    _context.SaveChanges();
    Console.WriteLine("Saved");
}