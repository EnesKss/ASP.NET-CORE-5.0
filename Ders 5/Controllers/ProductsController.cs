using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    // [ApiController] özelliği bu sınıfın bir Web API denetleyicisi olduğunu belirtir.
    // [Route] özelliği ise bu sınıftaki metotlara dışarıdan "api/products" URL'i ile ulaşılacağını belirler.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // ==========================================
        // 1. GET (READ - Okuma İşlemi)
        // ==========================================
        // İstemci (Client) GET isteği yolladığında bu metot tetiklenir.
        // Amaç: Veritabanındaki tüm ürünleri çekip Client'a listelemektir.
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok("Tüm ürünler veritabanından çekildi ve listelendi (HTTP GET).");
        }

        // ==========================================
        // 2. GET BY ID (READ - Tekil Okuma İşlemi)
        // ==========================================
        // URL Üzerinden Veri Alma (Route Data): api/products/5 (5 burada id'dir)
        // Amaç: Sadece spesifik bir ürünü (Örn: 5 ID'li ürün) getirmektir.
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok($"{id} numaralı ürünün detayları getirildi (HTTP GET).");
        }

        // ==========================================
        // 3. POST (CREATE - Yeni Kayıt Oluşturma)
        // ==========================================
        // Gövdeden Veri Alma (From Body): Yeni kayıt bilgileri URL'den değil, Request Body'den gelir.
        // Amaç: Client'ın gönderdiği JSON formatındaki veriyi alıp veritabanına yeni ürün olarak eklemektir.
        [HttpPost]
        public IActionResult CreateProduct([FromBody] string newProductDetails)
        {
            // İşlem başarılıysa (Kayıt eklendiyse) HTTP 201 (Created/Oluşturuldu) dönülmesi standarttır.
            return StatusCode(201, $"'{newProductDetails}' bilgileriyle yeni ürün başarıyla oluşturuldu (HTTP POST).");
        }

        // ==========================================
        // 4. PUT (UPDATE - Kayıt Güncelleme)
        // ==========================================
        // Hem URL'den (Hangi ürün güncellenecek?) hem de Body'den (Yeni veriler ne?) parametre alır.
        // Amaç: Belirli bir ürünün bilgilerini tamamen yenilemektir.
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] string updatedProductDetails)
        {
            return Ok($"{id} numaralı ürünün verileri '{updatedProductDetails}' olarak güncellendi (HTTP PUT).");
        }

        // ==========================================
        // 5. DELETE (DELETE - Kayıt Silme İşlemi)
        // ==========================================
        // Route Data: api/products/5
        // Amaç: İstemciden gelen ID bilgisine göre o ürünü veritabanından kalıcı olarak silmektir.
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"{id} numaralı ürün sistemden kalıcı olarak silindi (HTTP DELETE).");
        }
    }
}
