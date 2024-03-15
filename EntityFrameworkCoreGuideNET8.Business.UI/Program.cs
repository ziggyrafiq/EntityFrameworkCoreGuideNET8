// Example: is using Program.cs  file is kept in  Project EntityFrameworkCoreGuideNET8.Business.UI, which is ASP.net Core MVC Project
using EntityFrameworkCoreGuideNET8.Business.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Example: Configuring authentication and authorization in ASP.NET Core
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddAdminAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
