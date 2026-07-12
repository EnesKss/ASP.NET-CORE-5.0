using Microsoft.AspNetCore.Mvc;

namespace App.Backend
{
    // ==========================================
    // BACKEND (VERİ ÜRETEN VE İŞLEYEN KISIM) - AŞÇI
    // ==========================================
    // Bu Controller, sadece veriyi hazırlayıp dış dünyaya (API üzerinden) açmakla yükümlüdür.
    // Verinin hangi renkte, hangi fontta görüneceği ile ASLA ilgilenmez.
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // 1. İstek (Request) Karşılama Noktası (Mutfağın Teslimat Penceresi)
        [HttpGet]
        public IActionResult GetUsers()
        {
            // 2. Veri İşleme (Yemeğin Pişirilmesi)
            // Normalde bu veri Database'den çekilir, biz şimdilik sahte (mock) veri üretiyoruz.
            var mockUsers = new[]
            {
                new { Id = 1, Name = "Ahmet Yılmaz", Role = "Admin" },
                new { Id = 2, Name = "Ayşe Kaya", Role = "Standart Kullanıcı" }
            };

            // 3. Servis Etme (Yemeği JSON Tabağında Sunma)
            // Ok() metodu, veriyi saf JSON formatına dönüştürüp HTTP 200 ile dışarı fırlatır.
            return Ok(mockUsers);
        }
    }
}
