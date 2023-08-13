using EFCoreProjects.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build();

using (var _context = new AppDbContext(DbContextInitializer.optionsBuilder.Options))
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.ID} : {p.NAME} : {p.PRICE}");
    });
}