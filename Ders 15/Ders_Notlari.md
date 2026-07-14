# Ders 15: Action Dönüş Tipleri (Return Types) ve IActionResult Polimorfizmi

ASP.NET Core MVC mimarisinde Controller içindeki metotlar (Action'lar) işlemi bitirdikten sonra İstemciye (Client) bir "Sonuç" (Result) fırlatmak zorundadır. HTTP kuralları gereği bu sonuç her zaman bir HTML sayfası olmak zorunda değildir.

## 1. ViewResult vs PartialViewResult (Layout Mekanizması)
*   **ViewResult:** En standart dönüş tipidir. Arka planda `_ViewStart.cshtml` dosyasını tetikler. Bu sayede sizin ürettiğiniz küçük HTML parçası, devasa bir Master Page (Layout) şablonunun (Örn: Menüler, Footer) içine oturtulur. Sayfa bütünlüğü sağlanır.
*   **PartialViewResult:** "Kısmi Görünüm" anlamına gelir. Sistem `_ViewStart` ve Layout hiyerarşisini tamamen yok sayar (bypass eder). 
    *   *Mühendislik Kullanımı:* Ekrandaki bir butona basıldığında, tüm sayfayı yenilemek yerine AJAX ile sadece sayfanın bir bölgesini (Örn: Yorumlar sekmesini) güncellemek isterseniz `PartialViewResult` kullanırsınız. Layout'u tekrar tekrar yüklemediği için inanılmaz bir ağ (network) performansı sağlar.

## 2. JsonResult ve ContentResult (Content-Type Başlığı)
*   **JsonResult:** Elinizdeki C# nesnelerini (Örn: Bir ürün listesini) alır ve dışarı fırlatırken HTTP Header (Başlık) ayarlarındaki **`Content-Type`** değerini otomatik olarak `application/json` olarak işaretler. İstemci (tarayıcı veya mobil uygulama) gelen verinin düz bir metin değil, bir JSON veri kümesi olduğunu başlığa bakarak anlar.
*   **ContentResult:** Geriye hiçbir kurala bağlı olmayan, tamamen sizin manipüle edebileceğiniz sonuçlar döner. `Content-Type` başlığını `text/plain` (düz metin), `text/xml` veya `text/html` olarak bizzat siz belirlersiniz.

## 3. Endüstri Standardı: IActionResult Arayüzü (Interface)
Kurumsal (Enterprise) projelerde bir metodun sadece tek bir tipe (`ViewResult` veya `JsonResult`) mahkum edilmesi, esnekliğe aykırıdır. 
*   **Polimorfizm (Çok Biçimlilik):** ASP.NET Core, Nesne Yönelimli Programlama'nın (OOP) kalbi olan polimorfizmi burada kullanır. `ViewResult`, `JsonResult`, `PartialViewResult` gibi tüm tipler aslında arka planda **`IActionResult`** isimli ortak bir arayüzden (interface) türerler (implemente edilirler).
*   Bir Action metodunun dönüş tipini `IActionResult` olarak belirlerseniz; o metot aynı blok içerisinde duruma göre HTML çizebilir, hata fırlatabilir (NotFoundResult) veya JSON dönebilir. Bu esneklik onu endüstri standardı yapar.
