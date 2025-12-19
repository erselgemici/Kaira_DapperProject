using Kaira.WebUI.DTOs.ProductDtos;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductRepository _productRepository,
                                   ICategoryRepository _categoryRepository) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.categories = (from category  in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            await _productRepository.CreateAsync(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productRepository.UpdateAsync(productDto);
            return RedirectToAction("Index");
        }
    }
}
