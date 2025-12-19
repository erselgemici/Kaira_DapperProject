using Kaira.WebUI.DTOs.ProductDtos;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents
{
    public class ProductListViewComponent(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string type = "NewArrivals")
        {
            // 1. Veritabanındaki TÜM ürünleri çek (Repository'de değişiklik yapmadık)
            var allProducts = await _productRepository.GetAllAsync();

            // Gönderilecek listeyi tutacak değişken
            List<ResultProductDto> filteredProducts;

            // 2. Parametreye göre filtrele ve Başlığı Ayarla
            if (type == "BestSellers")
            {
                ViewBag.SectionTitle = "En Çok Satanlar";
                // Rastgele 4 ürün seç (Satış verisi olmadığı için fake mantık)
                filteredProducts = allProducts.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            }
            else if (type == "RelatedProducts")
            {
                ViewBag.SectionTitle = "Bunları da Beğenebilirsiniz";
                // Rastgele 4 ürün seç
                filteredProducts = allProducts.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            }
            else // Default: "NewArrivals"
            {
                ViewBag.SectionTitle = "Yeni Gelenler";
                // ID'si en büyük (en son eklenen) 4 ürünü al
                filteredProducts = allProducts.OrderByDescending(x => x.ProductId).Take(4).ToList();
            }

            // 3. Filtrelenmiş listeyi View'a gönder
            return View(filteredProducts);
        }
    }
}
