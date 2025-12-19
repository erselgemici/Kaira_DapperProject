using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class InstagramFeedViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
