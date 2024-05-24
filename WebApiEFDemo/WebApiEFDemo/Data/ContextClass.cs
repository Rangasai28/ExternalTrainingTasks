using Microsoft.EntityFrameworkCore;
using WebApiEFDemo.Models;

namespace WebApiEFDemo.Data;

public class ContextClass : DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }

    public DbSet<Employee> Employee {get; set;}

    public DbSet<Customer> Customer { get; set;}
}
