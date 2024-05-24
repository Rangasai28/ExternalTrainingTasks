using Microsoft.EntityFrameworkCore;
using WebApiAsyncAwaitDemo.Models;

namespace WebApiAsyncAwaitDemo.Data; 

public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> contextOptions) : base(contextOptions)
    { }

    public DbSet<Student> Customer { get; set; }

    public DbSet<Students> Students { get; set; }

    public DbSet<StudentD> Std {  get; set; }
}
