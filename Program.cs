using ChristiansClothes.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Add this using directive for EF Core
using System;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext setup
builder.Services.AddDbContext<ChristiansClothesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChristiansClothesContext") ?? throw new InvalidOperationException("Connection string 'ChristiansClothesContext' not found.")));

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();