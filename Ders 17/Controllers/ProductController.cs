using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using App.Models;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        // ==========================================
        // 1. LİSTELEME EKRANI (GET)
        // ==========================================
        public IActionResult Index()
        {
            // A) STRONGLY-TYPED MODEL: Asıl veriyi bu güvenli yolla taşıyoruz.
            // (Normalde veritabanından gelir, burada sahte bir liste oluşturuyoruz)
            var productList = new List<Product>
            {
                new Product { Id = 1, Name = "Oyuncu Laptop", Price = 35000 },
                new Product { Id = 2, Name = "Akıllı Telefon", Price = 25000 }
            };

            // B) VIEWBAG: Sayfa başlığı gibi yan (basit) verileri taşımak için idealdir.
            // Sadece bu istek süresince yaşar.
            ViewBag.Title = "Katalog Listesi - 2026";

            // Modeli (Listeyi) doğrudan View'a fırlatıyoruz.
            return View(productList);
        }

        // ==========================================
        // 2. YENİ ÜRÜN EKLEME SİMÜLASYONU (POST)
        // ==========================================
        public IActionResult Create()
        {
            // ... Veritabanına kayıt işlemi yapıldığını (başarılı olduğunu) varsayalım ...

            // C) TEMPDATA KULLANIMI:
            // İşlem bittikten sonra kullanıcıyı Index sayfasına "YÖNLENDİRİYORUZ (Redirect)".
            // Redirect işlemi tamamen yeni bir HTTP Request başlattığı için ViewBag ve ViewData burada ölür.
            // Sadece "TempData", veriyi Session/Cookie altyapısında saklayarak yönlendirme sonrası 
            // diğer sayfaya sağ salim taşıyabilir.
            TempData["Message"] = "Ürün başarıyla veritabanına eklendi!";

            return RedirectToAction("Index");
        }
    }
}
