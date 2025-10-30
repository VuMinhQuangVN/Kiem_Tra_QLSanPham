using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Data;
using QuanLySanPham.Models;
using QuanLySanPham.Helpers;
using QuanLySanPham.Repositories.Interfaces;

namespace QuanLySanPham.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Product>> GetAllAsync(string? searchString, int pageIndex, int pageSize)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(p => p.Name.Contains(searchString));
        }
        return await PaginatedList<Product>.CreateAsync(query, pageIndex, pageSize);
    }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}