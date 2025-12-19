using Kaira.WebUI.DTOs.TestimonialDtos;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _testimonialRepository.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialRepository.CreateAsync(createTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _testimonialRepository.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialRepository.UpdateAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
