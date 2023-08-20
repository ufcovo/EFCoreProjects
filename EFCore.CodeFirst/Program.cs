using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{

    _context.Update(new Product { Id = 2, Name = "Changed Book", Barcode = 12342, Price = 233, Stock = 6});
    //var newProduct = new Product { Name = "Pencil3", Price = 100, Stock = 33, Barcode = 31324 };
    //var product = await _context.Products.FirstAsync();
    //_context.Entry(product).State = EntityState.Detached;
    //Console.WriteLine($"İlk state: {_context.Entry(product).State}");

    //product.Name = "Changed Name";
    //_context.Remove(product);
    //_context.Entry(product).State = EntityState.Deleted;
    //product.Stock = 1000;
    //await _context.AddAsync(newProduct);
    //_context.Entry(product).State = EntityState.Added;    
    //Console.WriteLine($"Last state state: {_context.Entry(product).State}");

    await _context.SaveChangesAsync();
    //Console.WriteLine($"State after Save Change: {_context.Entry(product).State}");

    //var products = await _context.Products.ToListAsync();

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;

    //    Console.WriteLine($"{p.Id} : {p.Name} : {p.Price} : {p.Stock} state: {state}");
    //});
}