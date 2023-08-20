using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    _context.Products.Add(new() { Name = "Pencil 11", Price = 11, Stock = 2, Barcode = 234 });
    _context.Products.Add(new() { Name = "Pencil 12", Price = 11, Stock = 2, Barcode = 234 });
    _context.Products.Add(new() { Name = "Pencil 13", Price = 11, Stock = 2, Barcode = 234 });

    Console.WriteLine($"ContextID: {_context.ContextId}");


    //_context.SaveChanges();
}