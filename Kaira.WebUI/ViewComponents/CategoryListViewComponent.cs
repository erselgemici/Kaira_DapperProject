using Kaira.WebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class CategoryListViewComponent(ICategoryRepository _categoryRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryRepository.GetAllAsync();
            return View(values);
        }
    }
}
