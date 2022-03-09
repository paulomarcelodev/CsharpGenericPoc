namespace CsharpGenericPoc.Domain.Entities;

public interface IEntity
{
    int Id { get; set; }
}

public abstract class EntityBase : IEntity
{
    public int Id { get; set; }
}

public class Employee : EntityBase
{
    public string? FirstName { get; set; }

    public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
}

public class Manager : Employee
{
    public override string ToString() => base.ToString() + " (Manager)";
}

public class Organization : EntityBase
{
    public string? Name { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}";
}
