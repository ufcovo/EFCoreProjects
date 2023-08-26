using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    _context.Products.Add(new() { Name = "Pencil", Price = 100, Stock = 200, Barcode = 123, Kdv = 18 });
    _context.SaveChanges();


    Console.WriteLine("Saved");
}