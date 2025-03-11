using AspNetCore_App.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(c=> { 
    c.IdleTimeout = TimeSpan.FromMinutes(1); // 1 dakika sessioni sakla...
}); // sessions



// NorthwindDbContext sınıfının instance'sini register ediyoruz. aspnetcore yapısında instancelar default gelen ıOc (Inversion Of Control prensibi) kütüphanesinde register edilir...
builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("northcon"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // sessions


app.UseAuthorization();


app.MapControllerRoute(
    name:"area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
