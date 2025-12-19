using Kaira.WebUI.DTOs.MainSliderDtos;
using Kaira.WebUI.Repositories.IMainSliderRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainSliderController(IMainSliderRepository mainSliderRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collections = await mainSliderRepository.GetAllAsync();
            return View(collections);
        }
        public IActionResult CreateMainSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMainSlider(CreateMainSliderDto mainSliderDto)
        {
            await mainSliderRepository.CreateAsync(mainSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMainSlider(int id)
        {
            await mainSliderRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateMainSlider(int id)
        {
            var collection = await mainSliderRepository.GetByIdAsync(id);
            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMainSlider(UpdateMainSliderDto mainSliderDto)
        {
            await mainSliderRepository.UpdateAsync(mainSliderDto);
            return RedirectToAction("Index");
        }
    }
}
