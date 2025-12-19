using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.PartnerRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController(
        IProductRepository _productRepository,
        ICategoryRepository _categoryRepository,
        IPartnerRepository _partnerRepository,
        ITestimonialRepository _testimonialRepository
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Ürün Sayısı
            var products = await _productRepository.GetAllAsync();
            ViewBag.ProductCount = products.Count();

            // Kategori Sayısı
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.CategoryCount = categories.Count();

            // Marka Sayısı
            var partners = await _partnerRepository.GetAllAsync();
            ViewBag.PartnerCount = partners.Count();

            // Yorum Sayısı
            var testimonials = await _testimonialRepository.GetAllAsync();
            ViewBag.TestimonialCount = testimonials.Count();

            return View();
        }
    }
}
