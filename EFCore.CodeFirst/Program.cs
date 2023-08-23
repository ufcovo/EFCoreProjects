using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = new Category() { Name = "Books" };

    category.Products.Add(new () { Name = "Book 1", Price = 100, Stock = 100, Barcode = 123 });

    //_context.Categories.Add(category); Buna gerek yok. Navigation property den direkt olarak eklenmekte.
    _context.Add(category);
    _context.SaveChanges();
    Console.WriteLine("Saved");
}