// DTOs.cs file  in Project EntityFrameworkCoreGuideNET8.Infrastructure.Data
namespace EntityFrameworkCoreGuideNET8.Infrastructure.Domain.DTOs;
public record UserDto(Guid Id, string FirstName, string LastName, string Email, string Phone, bool IsActive);


public record OrderDto(Guid Id, Guid UserId, string ProductName, decimal Price, DateTime OrderDate);
