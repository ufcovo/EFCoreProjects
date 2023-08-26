using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //var student = new Student() { Name = "Mert", Age = 25 };
    //student.Teachers.Add(new() { Name = "Teacher of Halim"});
    //student.Teachers.Add(new() { Name = "Teacher of Ahmet" });

    //var teacher = new Teacher()
    //{
    //    Name = "Teacher of Mert",
    //    Students = new() {
    //    new() {Name = "Mert2", Age = 12},
    //    new() {Name = "Mert3", Age = 11}
    //    }
    //};

    var teacher = _context.Teachers.First(x => x.Name == "Teacher of Mert");
    teacher.Students.Add(new() { Name = "Kutlu", Age = 25});

    _context.SaveChanges();

    Console.WriteLine("Saved");
}