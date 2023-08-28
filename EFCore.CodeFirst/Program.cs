using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //_context.People.Add(new() { Name = "Mert", Phone = "05556667788" });
    //_context.People.Add(new() { Name = "Kutlu", Phone = "04445553322" });
    //_context.SaveChanges();
    Console.WriteLine("Saved");

    // First sitution
    var persons = _context.People.ToList().Where(r => FormatPhone(r.Phone) == "4445553322").ToList();

    // second sitution
    var person = _context.People.ToList().Select(r => new { PersonName = r.Name, PersonPhone = FormatPhone(r.Phone)}).ToList();
    Console.WriteLine("Done");
}

string FormatPhone(string phone)
{
    return phone.Substring(1, phone.Length - 1);
}