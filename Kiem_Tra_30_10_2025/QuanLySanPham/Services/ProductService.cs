using QuanLySanPham.DTOs;
using QuanLySanPham.Models;
using QuanLySanPham.Helpers;
using QuanLySanPham.Repositories.Interfaces;
using QuanLySanPham.Services.Interfaces;

namespace QuanLySanPham.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginatedList<ProductDto>> GetAllProductsAsync(string? searchString, int pageIndex, int pageSize)
        {
            var paginatedProducts = await _productRepository.GetAllAsync(searchString, pageIndex, pageSize);

            var productDtos = paginatedProducts.Items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            }).ToList();

            return new PaginatedList<ProductDto>(productDtos, paginatedProducts.PageIndex, paginatedProducts.TotalPages);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description
            };
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                Description = createProductDto.Description
            };
            
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = new Product
            {
                Id = updateProductDto.Id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                Stock = updateProductDto.Stock,
                Description = updateProductDto.Description
            };

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}