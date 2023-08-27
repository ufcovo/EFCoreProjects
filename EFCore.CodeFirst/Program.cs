using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    _context.Products.Add(new() { Name = "Pencil", Price = 100, Discount = 200, Barcode = 123, Stock = 2, Url = "abc"});

    _context.SaveChanges();
    Console.WriteLine("Saved");

}