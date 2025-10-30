using QuanLySanPham.DTOs;
using QuanLySanPham.Helpers;

namespace QuanLySanPham.Services.Interfaces
{
    public interface IProductService
    {
        Task<PaginatedList<ProductDto>> GetAllProductsAsync(string? searchString, int pageIndex, int pageSize);
        
        Task<ProductDto?> GetProductByIdAsync(int id);
        
        Task CreateProductAsync(CreateProductDto createProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(int id);
    }
}