using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

GetProducts(2, 6).ForEach(r =>
{
    Console.WriteLine($"{r.Id} {r.Name}");
});
static List<Product> GetProducts(int page, int pageSize)
{
    using (var _context = new AppDbContext())
    {
        #region DataInsert
        //var category = new Category() { Name = "Pencils" };
        //category.Products.Add(new() { Name = "Pencil 1", Price = 100, Stock = 100, Barcode = 100, ProductFeature = new() { Color = "Red", Height = 100, Width = 100 } });
        //category.Products.Add(new() { Name = "Pencil 2", Price = 200, Stock = 200, Barcode = 200, ProductFeature = new() { Color = "Blue", Height = 200, Width = 200 } });
        //category.Products.Add(new() { Name = "Pencil 3", Price = 300, Stock = 300, Barcode = 300, ProductFeature = new() { Color = "Yellow", Height = 300, Width = 300 } });
        //category.Products.Add(new() { Name = "Pencil 4", Price = 400, Stock = 400, Barcode = 400 });

        //_context.Categories.Add(category);
        //_context.SaveChanges(); 
        #endregion

        // page = 1 pageSize = 3 => First 3 data => skip:0 take: 3 (page -1)*pageSize => (1-1)*3 => 0
        // page = 2 pageSize = 3 => Second 3 data => skip:3 take: 3 (page -1)*pageSize => (2-1)*3 => 3
        // page = 3 pageSize = 3 => Third 3 data => skip:6 take: 3 (page -1)*pageSize => (3-1)*3 => 6
        return _context.Products.OrderByDescending(r => r.Id).Skip((page -1) * pageSize).Take(pageSize).ToList();


        //Console.WriteLine("");
    }
}



