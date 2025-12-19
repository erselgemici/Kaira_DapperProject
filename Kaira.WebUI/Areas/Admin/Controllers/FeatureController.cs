using Kaira.WebUI.DTOs.FeatureDtos;
using Kaira.WebUI.Repositories.FeatureRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IFeatureRepository _featureRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _featureRepository.GetAllAsync();
            return View(values);
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureRepository.CreateAsync(createFeatureDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _featureRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _featureRepository.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureRepository.UpdateAsync(updateFeatureDto);
            return RedirectToAction("Index");
        }
    }
}
