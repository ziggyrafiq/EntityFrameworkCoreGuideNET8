//DbContextMocker.cs class the file is kept in   Project EntityFrameworkCoreGuideNET8.Tests
using EntityFrameworkCoreGuideNET8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreGuideNET8.Tests;
public static class DbContextMocker
{
    public static DemoDbContext GetDemoDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<DemoDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        var dbContext = new DemoDbContext(options);

        // Seed your in-memory database with test data if needed

        return dbContext;
    }
}
