using CsharpGenericPoc.Application.Contracts;
using CsharpGenericPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsharpGenericPoc.Infrastructure.Persistence;

public class StorageAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Organization> Organizations => Set<Organization>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}

public class ListRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items;

    public ListRepository()
    {
        _items = new List<T>();
    }

    public IEnumerable<T> GetAll() => _items;

    public T GetById(int id) => _items.Single(item => item.Id == id);

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Remove(T item) => _items.Remove(item);

    public void Save()
    {
        // Already save in the List<T>
    }
}

public class SqlRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.OrderBy(item => item.Id);

    public T GetById(int id) => _dbSet.First(item => item.Id == id);

    public void Add(T item) => _dbSet.Add(item);

    public void Remove(T item) => _dbSet.Remove(item);

    public void Save() => _dbContext.SaveChanges();
}
