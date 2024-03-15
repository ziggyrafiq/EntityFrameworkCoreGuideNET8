// Example: Creating a Authorization.cs class the file is kept in Extensions Folder in Project EntityFrameworkCoreGuideNET8.Business.UI
namespace EntityFrameworkCoreGuideNET8.Business.UI.Extensions;
public static class Authorization
{
    public static void AddAdminAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
            {
                policy.RequireRole("Admin");
            });
        });
    }
}
