using Microsoft.EntityFrameworkCore;
using P2_2020_CP_601_2020_GH_601_2020_CG_650.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<covidContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("equiposDbConnection")
        )
);
// Add services to the container.
builder.Services.AddControllersWithViews();

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
