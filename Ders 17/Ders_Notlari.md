# Ders 17: View Yapılanması ve Katmanlar Arası Veri Taşıma Mekanizmaları

ASP.NET Core mimarisinde Controller (Arka Plan) ile View (Ön Yüz) birbirlerinden izole çalışır. Birinde üretilen verinin diğerinde gösterilebilmesi için teknik köprülere ihtiyaç vardır.

## 1. Razor Engine (.cshtml) ve Render Mekanizması
*   **`.cshtml` Evrensel Değildir:** HTML, tarayıcıların anladığı evrensel bir standarttır ancak `.cshtml` uzantılı dosyalar sadece ASP.NET (Microsoft) sunucuları tarafından anlaşılır. İçerisine yazılan C# kodları (`@` sembolü ile başlar) doğrudan tarayıcıya gönderilmez.
*   **Render (Derleme/Çizme) İşlemi:** Sunucu, bu dosyayı tarayıcıya yollamadan hemen önce çalıştırır. İçindeki C# kodlarının sonucunu alır, dümdüz bir HTML etiketine dönüştürür ve tarayıcıya sadece o temiz HTML kodunu fırlatır.

## 2. Controller'dan View'a Veri Taşıma Yöntemleri
Farklı senaryolara göre veriyi View'a taşımanın 4 temel yolu vardır:

*   **A) Strongly-Typed Model (Güçlü Tipli Model - En Güvenlisi):**
    Uygulamanın asıl verisi (Örn: Ürünler Listesi) doğrudan `return View(data)` ile gönderilir. Derleme (Compile-time) aşamasında hata kontrolü yapılır. Kod yazarken Intellisense (otomatik tamamlama) desteği sunar.

*   **B) ViewData (Dictionary Yapısı):**
    `ViewData["Title"] = "Ana Sayfa"` şeklinde çalışır. Veriyi "Object (Nesne)" tipinde (Boxing) tutar. Karşı tarafta (View'da) kullanırken orijinal tipine geri dönüştürmek (Unboxing / Casting) zorunludur. Yanlış tip dönüşümünde (Runtime) patlar.

*   **C) ViewBag (Dynamic Yapı):**
    Arka planda ViewData'nın aynısıdır ancak C# 4.0'ın "Dynamic" özelliğini kullanır. `ViewBag.Title = "Ana Sayfa"` şeklinde çalışır. View tarafında Casting (dönüştürme) gerektirmez. Intellisense desteği yoktur, yazım hatası yaparsanız proje derlenir ancak çalışırken (Runtime) sayfa çöker.

## 3. TempData ve Redirect (Yönlendirme) Senaryosu
*   **Ölüm (Yaşam Döngüsü):** Model, ViewBag ve ViewData verileri sadece tek bir HTTP isteği (Request) süresince yaşar. Eğer siz Controller'da bir kayıt işlemi yapıp, kullanıcıyı `RedirectToAction("Index")` koduyla başka bir Action'a yönlendirirseniz; arka planda *yeni bir HTTP isteği (Request)* başlatılır ve önceki sayfadaki tüm ViewBag/ViewData verileri **ölür (silinir)**.
*   **TempData'nın Gücü:** Bu tür sayfa yönlendirmelerinde "Kayıt Başarılı" gibi mesajları hayatta tutmak için `TempData` kullanılır. TempData veriyi arka planda geçici bir Cookie (Çerez) veya Session içine saklar. Yönlendirme bittiğinde veriyi okursunuz ve okunduğu an sistem veriyi çöpe atar (Tek seferlik okuma).
*   **Complex Types (Karmaşık Tipler) Sorunu:** TempData, Cookie altyapısı kullandığı için sadece basit tipleri (string, int) taşıyabilir. Eğer bir Personel Listesi (`List<Product>`) taşımak isterseniz bu listeyi "Metne" çevirmek zorundasınız. İşte burada nesneyi JSON metnine çeviren (Serialization) `JsonSerializer` yapısına ihtiyaç duyulur. Gittiği yerde bu metin tekrar Listeye (Deserialization) çevrilir.
