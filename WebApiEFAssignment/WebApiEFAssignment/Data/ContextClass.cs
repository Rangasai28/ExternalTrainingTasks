using Microsoft.EntityFrameworkCore;
using WebApiEFAssignment.Models;


namespace WebApiEFAssignment.Data
{
    public class ContextClass:DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
        { }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerProduct> CustomerProduct { get; set; }
    }
}
