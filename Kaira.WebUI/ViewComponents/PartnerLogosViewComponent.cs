using Kaira.WebUI.Repositories.PartnerRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class PartnerLogosViewComponent(IPartnerRepository _partnerRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _partnerRepository.GetAllAsync();
            return View(values);
        }
    }
}
