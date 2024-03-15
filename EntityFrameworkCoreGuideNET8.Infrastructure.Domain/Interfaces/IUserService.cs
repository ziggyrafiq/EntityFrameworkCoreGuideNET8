using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Models;

namespace EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Interfaces;

public interface IUserService: IService
{
    Task<List<User>> GetAllActiveUsersAsync();
}
