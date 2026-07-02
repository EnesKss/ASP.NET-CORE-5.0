using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // 1. GET (READ -> SQL: SELECT)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Tüm ürünler veritabanından çekildi (GET).");
        }

        // 2. POST (CREATE -> SQL: INSERT)
        [HttpPost]
        public IActionResult Post([FromBody] string productData)
        {
            return StatusCode(201, "Yeni ürün başarıyla eklendi (POST).");
        }

        // 3. PUT (Tam Güncelleme -> SQL: UPDATE)
        // İstemci, ürünün sadece adını değiştirecek olsa bile ad, fiyat, stok gibi 
        // tüm özelliklerini (property) bu metoda göndermek zorundadır.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string productFullData)
        {
            return Ok($"{id} numaralı ürün tüm özellikleri ezilerek güncellendi (PUT).");
        }

        // 4. PATCH (Kısmi Güncelleme -> SQL: UPDATE)
        // İstemci objenin tamamını değil, sadece değişen kısmı (Örn: Sadece yeni fiyat) gönderir.
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] string partialData)
        {
            return Ok($"{id} numaralı ürünün sadece talep edilen alanları güncellendi (PATCH).");
        }

        // 5. DELETE (Hard Delete -> SQL: DELETE FROM)
        // Veriyi fiziksel olarak diskten/veritabanından tamamen uçurur.
        [HttpDelete("{id}")]
        public IActionResult HardDelete(int id)
        {
            return Ok($"{id} numaralı ürün veritabanından kalıcı olarak SİLİNDİ (Hard Delete).");
        }

        // 6. SOFT DELETE (Mantıksal Silme -> SQL: UPDATE IsActive = 0)
        // Mimari Standart: Aslında bir silme işlemi değil, durum güncellemesi (Update) olduğu için
        // [HttpDelete] yerine [HttpPut] veya [HttpPatch] kullanılması daha doğru bir mühendislik yaklaşımıdır.
        // İstek 'api/product/softdelete/5' şeklinde atılır.
        [HttpPut("softdelete/{id}")]
        public IActionResult SoftDelete(int id)
        {
            // Pseudo Code: var urun = _db.Products.Find(id); urun.IsActive = false; _db.SaveChanges();
            return Ok($"{id} numaralı ürün fiziksel olarak silinmedi, sadece durumu 'Pasif (IsActive=false)' olarak GÜNCELLENDİ (Soft Delete).");
        }
    }
}
