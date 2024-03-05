using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Users.Infrastructure.DAL;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}