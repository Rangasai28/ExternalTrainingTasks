using Microsoft.EntityFrameworkCore;
using ArchitectureWebApi.Core.Models;

namespace ArchitectureWebApi.Infrastructure.Data;

public class Context:DbContext
{
    
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        { }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
    
}
