﻿using EFCoreProjects.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.ID} : {p.NAME} : {p.PRICE}");
    });
}