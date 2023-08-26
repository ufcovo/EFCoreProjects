using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var student = new Student() { Name = "Mert", Age = 25 };
    student.Teachers.Add(new() { Name = "Teacher of Halim"});
    student.Teachers.Add(new() { Name = "Teacher of Ahmet" });

    _context.Add(student);
    _context.SaveChanges();

    Console.WriteLine("Saved");
}