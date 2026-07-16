using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class OrderController : Controller
    {
        // ==========================================
        // 1. DIŞARIYA AÇIK ACTION (Endpoint / Uç Nokta)
        // ==========================================
        // İstemci (Client/Tarayıcı), adres satırına "site.com/Order/Create?price=100"
        // yazdığında Routing mekanizması doğrudan bu metodu bulur ve çalıştırır.
        
        public IActionResult Create(decimal price)
        {
            // İş mantığı (Sipariş oluşturma vb.) işletilirken, Controller içerisindeki 
            // yardımcı metoda (Helper) ihtiyaç duyuldu:
            decimal finalPrice = CalculateTax(price);

            // Gerçek senaryoda bu veri veritabanına kaydedilip View'a dönülür.
            return Ok($"Sipariş başarıyla oluşturuldu. Vergiler dahil tahsil edilecek tutar: {finalPrice} ₺");
        }

        // ==========================================
        // 2. DIŞARIYA KAPALI YARDIMCI METOT (Helper)
        // ==========================================
        // Bu metot, SADECE bu sınıfın içindeki diğer Action'ların (Örn: Create) 
        // vergi hesaplamasını yapması için yazılmış bir "İş/Business" metodudur.
        // 
        // GÜVENLİK (SECURITY):
        // Eğer [NonAction] YAZMASAYDIK; ASP.NET Core bunu varsayılan olarak bir Endpoint sanacak,
        // ve birisi URL üzerinden "site.com/Order/CalculateTax?amount=1000" yazarak 
        // bu metodu dışarıdan tetikleyebilecekti.
        // [NonAction] sayesinde Routing (Yönlendirme) mekanizması bu metodu GÖRMEZDEN GELİR 
        // ve dışarıdan yapılan isteklere 404 Hatası (Bulunamadı) döner.
        
        [NonAction]
        public decimal CalculateTax(decimal amount)
        {
            // Vergi hesaplama algoritması simülasyonu (%18 KDV)
            decimal taxRate = 0.18m;
            decimal taxAmount = amount * taxRate;
            
            return amount + taxAmount; 
        }
    }
}
