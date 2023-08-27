using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //var category = new Category() { Name = "Pencils" };
    //category.Products.Add(new Product()
    //{
    //    Name = "Pencil 1",
    //    Price = 100,
    //    Stock = 100,
    //    Barcode = 100,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 100,
    //        Width = 100
    //    }
    //});
    //category.Products.Add(new Product()
    //{
    //    Name = "Pencil 2",
    //    Price = 200,
    //    Stock = 200,
    //    Barcode = 200,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Blue",
    //        Height = 200,
    //        Width = 200
    //    }
    //});
    //category.Products.Add(new Product()
    //{
    //    Name = "Pencil 3",
    //    Price = 300,
    //    Stock = 300,
    //    Barcode = 300,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Yellow",
    //        Height = 300,
    //        Width = 300
    //    }
    //});

    //_context.Categories.Add(category);
    //_context.SaveChanges();


    var productFulls = _context.ProductFulls.FromSqlRaw(@"select p.Id 'Product_Id', c.Name 'CategoryName', p.Name, p.Price, pf.Height from Products p
join productFeatures pf on p.Id = pf.Id
join Categories c on p.CategoryId = c.Id").ToList();



    Console.WriteLine("Saved");

}