using Microsoft.EntityFrameworkCore;
using WebApiAutenticationDemo.Models;


namespace WebApiAutenticationDemo.Data;

public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UserRole { get; set; }  

}
