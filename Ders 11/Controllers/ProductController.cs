using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.Controllers
{
    // ==========================================
    // API CONTROLLER (Arayüzsüz - Headless Veri Sağlayıcı)
    // ==========================================
    // Bu sınıf HTML (View) DÖNDÜRMEZ! 
    // Yalnızca saf veri (JSON) döndürür. Bu sayede tarayıcı (Browser) bağımlılığı ortadan kalkar.
    // iOS, Android, Vue.js, Mikroservis veya bir Akıllı Saat (IoT) fark etmeksizin; 
    // HTTP isteği yapabilen her platform bu sınıf ile haberleşebilir.

    [Route("api/[controller]")]
    
    // [ApiController] Attribute'ü: 
    // MVC Controller'dan en temel farktır. Sisteme bu sınıfın bir API olduğunu, 
    // otomatik model doğrulama (validation) yapması gerektiğini ve 
    // View yerine JSON/XML formatter'ları kullanması gerektiğini söyler.
    [ApiController] 
    
    // API sınıfları 'Controller' yerine 'ControllerBase'den miras alır.
    // Çünkü 'Controller' sınıfı içerisinde View() metodu barındırır, API'nin ise View (HTML) ile işi yoktur.
    public class ProductController : ControllerBase 
    {
        // 1. GET 
        // Bir Akıllı TV uygulaması ekrandaki ürünleri listelemek için bu metodu (Sözleşmeyi) tüketebilir.
        // ActionResult<T>: Geriye dönecek verinin 'string listesi' olacağını garanti eden strongly-typed (güçlü tipli) yapıdır.
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetProducts()
        {
            var products = new List<string> { "Laptop", "Akıllı Telefon", "Giyilebilir Teknoloji" };
            return Ok(products); // Geriye otomatik olarak JSON formatında döner.
        }

        // 2. POST 
        // Bir Mobil Uygulama (Android/iOS) yeni ürün kaydederken HTTP Request'in Body kısmında JSON yollayarak buraya ulaşır.
        [HttpPost]
        public ActionResult<string> CreateProduct([FromBody] string productName)
        {
            // Veritabanına kayıt işlemi simülasyonu...
            return StatusCode(201, $"'{productName}' veritabanına başarıyla kaydedildi (Mobil cihazdan tetiklendi).");
        }

        // 3. PUT 
        // Kurumsal ağdaki başka bir Mikroservis (Örn: Stok Servisi), stok bitince ürünü pasife çekmek için burayı tetikleyebilir.
        [HttpPut("{id}")]
        public ActionResult<string> UpdateProduct(int id, [FromBody] string newName)
        {
            return Ok($"{id} numaralı ürünün yeni adı '{newName}' olarak güncellendi.");
        }

        // 4. DELETE 
        // React JS ile yazılmış Admin panelindeki bir web istemcisi bu metot ile kaydı silebilir.
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduct(int id)
        {
            return Ok($"{id} numaralı ürün sistemden kalıcı olarak silindi.");
        }
    }
}
