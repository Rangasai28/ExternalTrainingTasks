using Microsoft.EntityFrameworkCore;
using ApiProductCustomerAsync.Models;

namespace ApiProductCustomerAsync.Data;

public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }

   // public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    //public DbSet<CustomerProduct> CustomerProducts { get; set; }
}
