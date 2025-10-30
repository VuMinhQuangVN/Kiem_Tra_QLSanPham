using Microsoft.AspNetCore.Mvc;
using QuanLySanPham.DTOs;
using QuanLySanPham.Services.Interfaces;

namespace QuanLySanPham.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string? searchString, int? pageIndex)
    {
        const int pageSize = 10; 
        int currentPageIndex = pageIndex ?? 1;

        ViewData["CurrentFilter"] = searchString;
        var paginatedProducts = await _productService.GetAllProductsAsync(searchString, currentPageIndex, pageSize);
    
        return View(paginatedProducts);
    }
        // GET: /Products/Details/...
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return View(product); 
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Chống tấn công CSRF
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {

            if (ModelState.IsValid)
            {
                await _productService.CreateProductAsync(createProductDto);
                return RedirectToAction(nameof(Index));
            }
            return View(createProductDto);
        }

        // GET: /Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            if (productDto == null)
            {
                return NotFound();
            }
            
            // Cần map từ ProductDto sang UpdateProductDto để gửi cho View Edit
            var updateProductDto = new UpdateProductDto
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description
            };

            return View(updateProductDto);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(updateProductDto);
                return RedirectToAction(nameof(Index));
            }
            return View(updateProductDto);
        }

        // GET: /Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}