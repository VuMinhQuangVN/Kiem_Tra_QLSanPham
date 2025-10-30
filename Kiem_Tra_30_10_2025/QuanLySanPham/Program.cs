
using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Data;
using QuanLySanPham.Repositories;
using QuanLySanPham.Repositories.Interfaces;
using QuanLySanPham.Services; 
using QuanLySanPham.Services.Interfaces; 

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>(); 


builder.Services.AddControllersWithViews();



var app = builder.Build();

// --- CẤU HÌNH HTTP REQUEST PIPELINE ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

