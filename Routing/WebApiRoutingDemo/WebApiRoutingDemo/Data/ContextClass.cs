using Microsoft.EntityFrameworkCore;
using WebApiRoutingDemo.Models;

namespace WebApiRoutingDemo.Data;

public class ContextClass : DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }

    public DbSet<Employee> Customer { get; set; }

    
}