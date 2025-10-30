using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Models;

namespace QuanLySanPham.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}