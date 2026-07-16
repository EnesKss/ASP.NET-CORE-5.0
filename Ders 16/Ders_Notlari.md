# Ders 16: [NonAction] ve [NonController] Nitelikleri (Güvenlik ve İzolasyon)

ASP.NET Core MVC mimarisinde Controller'lar, sistemin dış dünyaya açılan kapılarıdır. Bu kapıların kontrolü ve güvenliği, mimarinin dayanıklılığı açısından kritik bir öneme sahiptir.

## 1. Controller'ın Asıl Görevi: Orkestrasyon
Yazılım mühendisliği prensiplerine göre Controller katmanının amacı **"İş Yapmak (Business Logic)" değil, "İşi Yönlendirmek"tir (Orchestration).** Bir orkestra şefi keman çalmaz, kime ne zaman çalması gerektiğini söyler. Controller da veritabanı işlemlerini, hesaplamaları (Amelelikleri) yapmaz; isteği (Request) karşılar, ilgili servisleri çağırır ve sonucu View'a fırlatır.
Ancak bazen pratik nedenlerle, Controller'ın içerisine küçük yardımcı (Helper) metotlar yazmak zorunda kalabiliriz. İşte güvenlik zafiyeti burada başlar.

## 2. [NonAction] Niteliğinin Güvenlik Açısından Zorunluluğu
*   **Tehlike:** ASP.NET Core Routing (Yönlendirme) mekanizması, bir Controller sınıfı içerisine yazılmış tüm `public` metotları, dışarıdan HTTP isteğiyle tetiklenebilen birer **Action (Uç Nokta / Endpoint)** olarak kabul eder.
*   **Sorun:** Siz sadece `Create` metodunuzun içinden çağırmak üzere `VergiHesapla()` adında public bir yardımcı metot yazarsanız; kötü niyetli biri adres çubuğuna `site.com/Order/VergiHesapla` yazarak bu metodu dışarıdan tetikleyebilir ve sisteminize zarar verebilir.
*   **Çözüm:** Yardımcı metotların üzerine **`[NonAction]`** özniteliği (attribute) eklenir. Sistem bu etiketi gördüğünde, *"Bu bir uç nokta değil, sadece iç kullanım içindir"* der ve dışarıdan gelen URL isteklerine (404 Not Found) hatası dönererek güvenlik sağlar.

## 3. [NonController] Niteliği ve İzolasyon
*   **Convention (Gelenek) Kuralı:** ASP.NET Core, isminin sonu `Controller` ile biten veya temel `Controller` sınıfından kalıtım alan her sınıfı otomatik olarak "İstek Karşılayıcı" olarak kabul eder ve Routing mekanizmasına dahil eder.
*   **Çözüm:** Mimari tasarım gereği (örneğin miras alma senaryolarında Base class oluştururken) isminin sonu Controller ile biten ancak **asla** dışarıdan HTTP isteği almasını istemediğiniz bir temel sınıf yaratıyorsanız; bu sınıfı HTTP isteklerinden tamamen izole etmek (Routing listesinden çıkartmak) için sınıfın başına **`[NonController]`** eklemeniz yeterlidir.
