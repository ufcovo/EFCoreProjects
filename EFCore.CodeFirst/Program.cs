using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = _context.Categories.First(x => x.Name == "Books");
    var product = new Product() { Name = "Book 1", Price = 100, Stock = 100, Barcode = 123, CategoryId = category.Id };

    _context.Add(category);
    _context.SaveChanges();
    Console.WriteLine("Saved");
}