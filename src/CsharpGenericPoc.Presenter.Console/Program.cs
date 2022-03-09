// See https://aka.ms/new-console-template for more information

using CsharpGenericPoc.Domain.Entities;
using CsharpGenericPoc.Infrastructure.Persistence;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
employeeRepository.Add(new Employee { FirstName = "Julia" });
employeeRepository.Add(new Employee { FirstName = "Anna" });
employeeRepository.Add(new Employee { FirstName = "Thomas" });
employeeRepository.Add(new Manager { FirstName = "Sara" });
employeeRepository.Add(new Manager { FirstName = "Henry" });
employeeRepository.Save();
var employee = employeeRepository.GetById(2);
var manager = employeeRepository.GetById(4);
Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
Console.WriteLine($"Manager with Id 4: {manager.FirstName}");
foreach (var item in employeeRepository.GetAll())
{
    Console.WriteLine(item);
}
