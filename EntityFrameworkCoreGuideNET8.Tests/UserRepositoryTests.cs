//UserRepositoryTests.cs class the file is kept in   Project EntityFrameworkCoreGuideNET8.Tests
using EntityFrameworkCoreGuideNET8.Infrastructure.Data.Repository;

namespace EntityFrameworkCoreGuideNET8.Tests;

public class UserRepositoryTests
{
    // Example: Writing unit tests for EF Core repositories

    [Fact]
    public async Task GetUsers_ReturnsAllUsers()
    {
        // Arrange
        var dbContext = DbContextMocker.GetDemoDbContext(nameof(GetUsers_ReturnsAllUsers));
        var repository = new UserRepository(dbContext);

        // Act
        var users = await repository.GetAllActiveUsersAsync();

        // Assert
        Assert.Equal(3, users.Count);
    }

}