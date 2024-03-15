// Example: Creating a User record the file is kept in Models Folder in Project EntityFrameworkCoreGuideNET8.Infrastructure.Data
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Models;
public record User
{
    [Key]
    public Guid Id { get; init; }

    public List<Order> Orders { get; init; } = new List<Order>();

    [Required]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    public string LastName { get; init; } = string.Empty;

    [Required]
    public string Email { get; init; } = string.Empty;

    [Required]
    public string EmailConfirmed { get; init; } = string.Empty;

    [Required]
    public string Phone { get; init; } = string.Empty;

    [Required]
    public string PhoneConfirmed { get; init; } = string.Empty;

    public bool IsActive { get; init; } = false;

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}
