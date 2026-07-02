using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    // SUNUCU (SERVER) katmanında yaşayan Controller sınıfımız.
    // Görevi: Dünyanın herhangi bir yerindeki İstemciden (Client) gelen istekleri yakalamaktır.
    public class HomeController : Controller
    {
        // 1. REQUEST (İSTEK) ALIMI:
        // Client tarayıcı adres satırına "site.com/Home/Index" yazdığında, 
        // DNS çözümlenir ve sunucuya bir HTTP GET İstediği (Request) ulaşır.
        // ASP.NET Core bu 'Request'i alır ve tam olarak bu Action metoduna yönlendirir.
        public IActionResult Index()
        {
            // 2. SERVER'DA İŞLEME (PROCESSING):
            // İstek başarıyla yakalandı. Artık sunucu içindeyiz. 
            // Burada veritabanı sorguları çalıştırılabilir, iş kuralları denetlenebilir.
            var islenenVeri = "Sunucu gelen 'Request'i başarıyla aldı ve işledi.";

            // 3. RESULT (SONUÇ):
            // İşlem sonucunda hafızada (RAM) elde edilen teknik/ham veridir.
            // Bu sonucun Client'a gönderilmeden önce paketlenmesi gerekir.

            // 4. RESPONSE (YANIT) GÖNDERİMİ:
            // Ok() metodu, HTTP 200 (Her Şey Yolunda) durum kodunu barındıran bir "Response" yaratır.
            // İçerisine koyduğumuz Result nesnesini otomatik olarak JSON formatına çevirir 
            // ve Client'a (İstemciye) geriye "Response (Yanıt)" olarak fırlatır.
            return Ok(new 
            { 
                Durum = "Başarılı",
                Mesaj = islenenVeri,
                KavramsalNot = "Ekranda gördüğün bu JSON metni, uygulamanın 'Response'udur."
            });
        }
    }
}
