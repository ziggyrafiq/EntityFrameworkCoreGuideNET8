// Example: Creating a DemoDbContext class the file is kept in DbContext Folder in Project EntityFrameworkCoreGuideNET8.Infrastructure.Data

using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreGuideNET8.Infrastructure.Data;
public class DemoDbContext: DbContext
{
    
    public DemoDbContext(DbContextOptions options) : base(options)
    {
    
    }

    public DbSet<User> Users { get; set; }
    // Other DbSet properties for additional entities

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("OurConnectionString");
    }

    // Example: Creating a database index in EF Core
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Fluent API configurations
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .IsRequired();

    }

}
