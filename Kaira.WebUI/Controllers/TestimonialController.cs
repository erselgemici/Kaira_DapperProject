using Kaira.WebUI.DTOs.TestimonialDtos;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            await _testimonialRepository.CreateAsync(testimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialRepository.GetByIdAsync(id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto testimonialDto)
        {
            await _testimonialRepository.UpdateAsync(testimonialDto);
            return RedirectToAction("Index");
        }
    }
}
