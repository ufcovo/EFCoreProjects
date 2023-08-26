using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //_context.Manager.Add(new Manager() { FirstName = "m1", LastName = "m1", Age = 22, Grade = 1 });
    //_context.Employee.Add(new Employee() { FirstName = "e1", LastName = "e1", Age = 22, Salary = 10 });
    //_context.SaveChanges();

    var manager = _context.Manager.ToList();
    var employees = _context.Employee.ToList();
    var person = _context.Person.ToList();

    person.ForEach(r =>
    {
        switch (r)
        {
            case Manager manager:
                Console.WriteLine($"Manager entitty: {manager.Grade}");
                break;

            case Employee employee:
                Console.WriteLine($"Employee entitty: {employee.Salary}");
                break;
            default:
                break;
        }
    });

}