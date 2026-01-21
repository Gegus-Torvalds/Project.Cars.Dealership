using Microsoft.EntityFrameworkCore;
using Cars.Dealership.Infrastructure.StartupExtensions;
using Cars.Dealership.Infrastructure.DatabaseContext;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//  explore this line more?
builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    //  explore this and rethink why it does not work in this case?
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated(); // <- ovdje kreira bazu i tabele ako ne postoje
}

app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.Run();
