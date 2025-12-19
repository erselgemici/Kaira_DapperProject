using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class TestimonialViewComponent(ITestimonialRepository _testimonialRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialRepository.GetAllAsync();
            return View(values);
        }
    }
}
