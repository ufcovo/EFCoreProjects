using EFCore.DatabaseFirst.ByScaffold.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new EFCoreDatabaseFirstDBContext())
{
    var products = await context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} : {p.Price} : {p.Stock}");
    });
}