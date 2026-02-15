using Microsoft.EntityFrameworkCore;
using Cars.Dealership.Infrastructure.StartupExtensions;
using Cars.Dealership.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Cars.Dealership.Core.Domain.IdentityEntities;
using Cars.Dealership.Core.Enums;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//  adding services from extension method
builder.Services.AddInfrastructureServices(builder.Configuration);



//  adding authorization,cannot be added from extension method
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
});




var app = builder.Build();




//creating roles
using (var scope = app.Services.CreateScope())
{
    RoleManager<ApplicationRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    string[] roles = { UserTypeOptions.Admin.ToString(), UserTypeOptions.User.ToString() };

    foreach(var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            IdentityResult result = await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = role
            });
            System.Console.WriteLine("ROLE CREATED");
        }
    }
}

// adding middleware, must be in this order
app.UseStaticFiles();
app.UseRouting(); 
app.UseAuthentication(); 
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();
