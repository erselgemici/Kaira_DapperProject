using Kaira.WebUI.DTOs.PartnerDtos;
using Kaira.WebUI.Repositories.PartnerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartnerController(IPartnerRepository _partnerRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _partnerRepository.GetAllAsync();
            return View(values);
        }

        public IActionResult CreatePartner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner(CreatePartnerDto createPartnerDto)
        {
            await _partnerRepository.CreateAsync(createPartnerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePartner(int id)
        {
            await _partnerRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePartner(int id)
        {
            var value = await _partnerRepository.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePartner(UpdatePartnerDto updatePartnerDto)
        {
            await _partnerRepository.UpdateAsync(updatePartnerDto);
            return RedirectToAction("Index");
        }
    }
}
