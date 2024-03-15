// Example: Creating a JwtAuthentication.cs class the file is kept in Extensions Folder in Project EntityFrameworkCoreGuideNET8.Business.UI

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EntityFrameworkCoreGuideNET8.Business.UI.Extensions;
public static  class JwtAuthentication
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        // Example: Configuring authentication and authorization in ASP.NET Core
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });


    }
}
