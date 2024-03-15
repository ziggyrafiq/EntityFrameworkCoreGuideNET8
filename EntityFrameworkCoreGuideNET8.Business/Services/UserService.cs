using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Interfaces;
using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Models;


namespace EntityFrameworkCoreGuideNET8.Business.Services;

public class UserService : IUserService 
{
    private bool _disposed = false;
    private readonly IUserRepository? _userRepository; 

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllActiveUsersAsync() =>
        _userRepository != null ? _userRepository.GetAllActiveUsersAsync() :
        throw new InvalidOperationException("User repository is not initialized.");



    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing && _userRepository != null)
            _userRepository.Dispose();

        _disposed = true;
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

