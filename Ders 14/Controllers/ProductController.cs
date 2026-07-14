using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers
{
    // ==========================================
    // CONTROLLER KATMANI
    // ==========================================
    // "Convention over Configuration" Kuralı 1: 
    // Sınıf adı 'Controller' eki ile bitmeli ve temel 'Controller' sınıfından miras almalıdır.
    public class ProductController : Controller
    {
        // İstemci (Client) "site.com/Product/GetProducts" URL'sine geldiğinde bu metot tetiklenir.
        public IActionResult GetProducts()
        {
            // 1. VERİ TEMİNİ: Veritabanından gelmiş gibi sahte bir Model üretiyoruz.
            var urun = new Product
            {
                Id = 101,
                Name = "Oyuncu Bilgisayarı",
                Price = 35000
            };

            // 2. VERİYİ VIEW'A AKTARMA (RENDER İŞLEMİ)
            // "Convention over Configuration" Kuralı 2:
            // Sadece return View() dediğimiz için, sistem otomatik olarak "Views/Product/GetProducts.cshtml" dizinini arar.
            // Ayrıca bulduğu o dosyaya "urun" nesnesini (@model olarak kullanması için) paketleyip fırlatır.
            return View(urun);
        }
    }
}
