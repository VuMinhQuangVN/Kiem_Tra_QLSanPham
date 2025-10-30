using QuanLySanPham.Models;
using QuanLySanPham.Helpers;

namespace QuanLySanPham.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<PaginatedList<Product>> GetAllAsync(string? searchString, int pageIndex, int pageSize);

        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id);
    }
}