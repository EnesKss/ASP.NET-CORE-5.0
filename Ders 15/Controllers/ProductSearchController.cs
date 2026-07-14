using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ProductSearchController : Controller
    {
        // ==========================================
        // IActionResult İLE POLİMORFİK (ÇOK BİÇİMLİ) ACTION METODU
        // ==========================================
        // Geri dönüş tipi olarak 'ViewResult' veya 'JsonResult' yazsaydık, 
        // bu metot tek bir formata mahkum olurdu (Esnekliğini yitirirdi).
        // Ancak ortak arayüz olan 'IActionResult' sayesinde aşağıdaki metot 
        // duruma göre yepyeni kılıklara (HTML veya JSON) bürünebilir.

        public IActionResult SearchProduct(int id, bool isAjaxRequest)
        {
            // 1. DURUM: HATA SENARYOSU (Ürün Bulunamadıysa)
            if (id <= 0)
            {
                // Bir sorun var! HTML sayfasını ziyan etmeye gerek yok.
                // İstemciye (Client) derdini anlatan saf bir JSON objesi fırlatıyoruz.
                // HTTP Başlığı otomatik olarak "Content-Type: application/json" ayarlanır.
                var errorResponse = new { Code = 404, Message = "Hata: Geçersiz ID veya ürün bulunamadı!" };
                
                return Json(errorResponse); // Arka planda JsonResult nesnesine dönüşür.
            }

            // --- Başarılı Senaryoya Geçiş ---
            // Veritabanından gelmiş gibi sahte (Mock) bir model üretiyoruz.
            var productInfo = new { Id = id, Name = "Premium Oyuncu Bilgisayarı", Price = 45000 };

            // 2. DURUM: AJAX (Arka Plan) İSTEĞİ
            if (isAjaxRequest)
            {
                // İstek, tarayıcı sayfasını yenilemeden arka planda (AJAX ile) veya bir 
                // Mobil Uygulamadan atılmış olabilir. Bu durumda koca bir Layout (Menüler, Footer) 
                // dönmek çok mantıksızdır. Sadece ham veriyi JSON olarak fırlatıyoruz.
                
                return Json(productInfo); // Arka planda JsonResult nesnesine dönüşür.
            }

            // 3. DURUM: KLASİK TARAYICI İSTEĞİ (HTML Çizimi)
            // Her şey yolunda ve istek tarayıcının adres satırından (URL) geldi.
            // Bu durumda ürünü (Model'i) görselleştirmesi için View katmanına fırlatıyoruz.
            // Arka planda _ViewStart ve Layout (Master Page) devreye girecek, sayfa bütünlüğü sağlanacaktır.
            
            return View(productInfo); // Arka planda ViewResult nesnesine dönüşür.
        }
    }
}
