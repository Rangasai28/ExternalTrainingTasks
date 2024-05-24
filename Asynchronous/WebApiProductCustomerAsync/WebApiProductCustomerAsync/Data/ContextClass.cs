using Microsoft.EntityFrameworkCore;
using WebApiProductCustomerAsync.Models;

namespace WebApiProductCustomerAsync.Data;

public class ContextClass : DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }
    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<CustomerProduct> CustomerProducts { get; set; }
}
