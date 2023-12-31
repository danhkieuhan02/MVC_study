using eShopMVCNet7.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<eShopDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
}); // nho code vao


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

//Add th�m route cho admin
app.MapAreaControllerRoute(
name: "Admin",
areaName : "Admin",
pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
