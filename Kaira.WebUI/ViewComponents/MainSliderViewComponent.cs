using Kaira.WebUI.Repositories.IMainSliderRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class MainSliderViewComponent(IMainSliderRepository _mainSliderRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _mainSliderRepository.GetAllAsync();
            return View(values);
        }
    }
}
