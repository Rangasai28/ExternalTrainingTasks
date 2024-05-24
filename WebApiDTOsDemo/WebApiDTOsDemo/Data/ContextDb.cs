using Microsoft.EntityFrameworkCore;
using WebApiDTOsDemo.Models;

namespace WebApiDTOsDemo.Data;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> contextOptions) : base(contextOptions)
    { }

    public DbSet<Student> Students { get; set; }
}
