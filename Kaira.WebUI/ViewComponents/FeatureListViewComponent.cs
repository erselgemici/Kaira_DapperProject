using Kaira.WebUI.Repositories.FeatureRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class FeatureListViewComponent(IFeatureRepository _featureRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureRepository.GetAllAsync();
            return View(values);
        }
    }
}
