using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents
{
    public class AiAssistantViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
