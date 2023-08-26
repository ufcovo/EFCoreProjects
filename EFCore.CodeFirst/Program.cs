using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //var category = new Category()
    //{
    //    Name = "Pencils",
    //    Products = new List<Product>()
    //    {
    //        new() {Name = "Pencil1" , Price = 100, Stock = 200, Barcode = 123},
    //        new() {Name = "Pencil2" , Price = 200, Stock = 100, Barcode = 124}
    //    }
    //};

    //_context.Add(category);

    var category = _context.Categories.First();
    var products = _context.Products.Where(x => x.CategoryId == category.Id).ToList();
    _context.Products.RemoveRange(products);
    _context.Categories.Remove(category);
    _context.SaveChanges();



    Console.WriteLine("Saved");
}