using Kaira.WebUI.DTOs.CategoryDtos;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryRepository _categoryRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            await _categoryRepository.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            await _categoryRepository.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }

    }
}
