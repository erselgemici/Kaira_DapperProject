using Kaira.WebUI.DTOs.AiInteractionDtos;
using Kaira.WebUI.Repositories.AiInteractionRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Kaira.WebUI.Controllers
{
    public class AiAssistantController(IAiInteractionRepository _aiRepository,
        IProductRepository _productRepository) : Controller
    {
        //AIzaSyAmagLTQAsleLnlMX6iCPepAMK2QKY0pis

        [HttpPost]
        public async Task<IActionResult> AskAi([FromBody] CreateAiInteractionDto model)
        {
            if (string.IsNullOrEmpty(model.UserQuery)) return Json(new { success = false, message = "Lütfen bir soru yazın." });

            // API Key'in (Cloud Console'dan aldığın çalışan anahtar)
            string apiKey = "AIzaSyAmagLTQAsleLnlMX6iCPepAMK2QKY0pis";

            try
            {
                // 2. Veritabanındaki Ürünleri Çekiyoruz
                // (Not: GetAllAsync metodun yoksa IProductRepository'ye eklemelisin, veya GetNewArrivalsAsync gibi bir listeyi de kullanabilirsin)
                var products = await _productRepository.GetAllAsync();

                // 3. Ürünleri Metne Dönüştür (AI'ın okuyabileceği format)
                // Örnek Çıktı: "- Kırmızı Yazlık Elbise (500 TL) - Mavi Jean (300 TL)..."
                var productListText = string.Join("\n", products.Select(p => $"- Ürün Adı: {p.Name}, Fiyat: {p.Price} TL"));

                // 4. Gemini'ye Talimatı Hazırla (Prompt Engineering)
                string systemInstruction = "Sen Kaira Mağazası'nın yapay zeka satış danışmanısın. " +
                                           "Görevin: Kullanıcının sorusuna göre AŞAĞIDAKİ ÜRÜN LİSTESİNDEN en uygun ürünleri önermek. " +
                                           "Kurallar: \n" +
                                           "1. Sadece listedeki ürünleri öner, hayali ürün uydurma. \n" +
                                           "2. Ürünlerin fiyatlarını mutlaka belirt. \n" +
                                           "3. Samimi ve satış odaklı ol. \n\n" +
                                           "STOKTAKİ ÜRÜNLERİMİZ:\n" + productListText;

                string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

                var payload = new
                {
                    contents = new[] {
                        new {
                            parts = new[] {
                                new { text = systemInstruction + "\n\nKullanıcı Sorusu: " + model.UserQuery }
                            }
                        }
                    }
                };

                using (var httpClient = new HttpClient())
                {
                    var jsonPayload = JsonSerializer.Serialize(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return Json(new { success = false, message = "Google Hatası: " + responseString });
                    }

                    try
                    {
                        var jsonNode = JsonNode.Parse(responseString);

                        // Doğru okuma yöntemi (Önceki hatayı düzelten kısım)
                        string answer = jsonNode?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                        if (string.IsNullOrEmpty(answer))
                        {
                            // Yedek kontrol
                            answer = jsonNode?["candidates"]?[0]?["content"]?[0]?["parts"]?[0]?["text"]?.ToString();
                        }

                        if (string.IsNullOrEmpty(answer)) return Json(new { success = false, message = "Cevap üretilemedi." });

                        return Json(new { success = true, answer = answer });
                    }
                    catch (Exception)
                    {
                        return Json(new { success = false, message = "JSON Hatası." });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sistem Hatası: " + ex.Message });
            }
        }
    }
}
