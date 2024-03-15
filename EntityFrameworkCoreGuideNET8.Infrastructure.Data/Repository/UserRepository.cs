// Example: Creating a UserRepository class the file is kept in Repository Folder in Project EntityFrameworkCoreGuideNET8.Infrastructure.Data
using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.DTOs;
using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Interfaces;
using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreGuideNET8.Infrastructure.Data.Repository;
public class UserRepository : IUserRepository
{
    private readonly DemoDbContext _dbContext;
    private bool _disposed = false;

    public UserRepository(DemoDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// This example demonstrates the usage of UserDto for accessing the data.
    /// </summary>
    /// <returns>List of Users</returns>
    public Task<List<UserDto>> GetUserDtosAsync() => _dbContext.Users
      .Select(u => new UserDto(
          u.Id,
          u.FirstName,
          u.LastName,
          u.Email,
          u.Phone,
          u.IsActive
      ))
      .ToListAsync();


    /// <summary>
    /// This is an Example Querying data with LINQ
    /// </summary>
    /// <returns>List</returns>
    public Task<List<User>> GetAllActiveUsersAsync() =>
      _dbContext.Users
          .Where(u => u.IsActive)
          .OrderBy(u => u.LastName)
          .ThenBy(u => u.FirstName)
          .ToListAsync();


    /// <summary>
    /// This example is  Eager loading in EF Core
    /// </summary>
    /// <returns></returns>
    public Task<List<User>> LoadUsersWithOrdersAsync() =>
     _dbContext.Users
        .Include(u=>u.Orders)
         .Where(u => u.IsActive)
         .OrderBy(u => u.LastName)
         .ThenBy(u => u.FirstName)
         .ToListAsync();


    /// <summary>
    /// Add or Updates the User
    /// </summary>
    /// <param name="user">User Model</param>
    /// <returns></returns>
    public async Task SaveAsync(User user)
    {
        try
        {
            _dbContext.Entry(user).State = user.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("An error occurred while saving changes to the database: " + ex.Message);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _dbContext.Dispose();
        }

        _disposed = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
