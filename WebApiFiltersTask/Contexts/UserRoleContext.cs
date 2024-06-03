using Microsoft.EntityFrameworkCore;
using WebApiFiltersTask.Models;
namespace WebApiFiltersTask.Contexts;

public class UserRoleContext:DbContext
{
    public UserRoleContext(DbContextOptions<UserRoleContext> contextOptions) : base(contextOptions)
    { }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<RoleBasedAction> RoleBasedActions { get; set; }

    public DbSet<UserLogin> Handlers { get; set; }
}
