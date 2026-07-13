# Ders 12: ASP.NET Core 5.0 Proje Dosya Yapısı ve Çekirdek Konfigürasyon

Boş bir ASP.NET Core projesi oluşturduğunuzda, arka planda devasa bir web sunucusu (Kestrel) çalıştıran, ancak özünde basit bir Console (Konsol) uygulamasından farksız olan temiz bir dizin yapısıyla karşılaşırsınız.

## 1. Temel Dizin Yapısı ve Görevleri

*   **Dependencies (Bağımlılıklar):** Projenin dış dünyayla olan tüm bağlantılarının (NuGet paketleri, Entity Framework Core gibi dış kütüphaneler, kurulu SDK'lar) listelendiği sanal dizindir.
*   **Properties (Özellikler):** Projenin derleme ve çalışma zamanı ayarlarını barındırır. İçerisindeki `launchSettings.json` dosyası; uygulamanın IIS Express ile mi yoksa doğrudan Kestrel (Project profili) ile mi çalışacağını, hangi portları kullanacağını belirler.

## 2. Program.cs (Giriş Noktası ve Sunucu Kurulumu)
ASP.NET Core uygulamaları aslında birer konsol uygulamasıdır. Her konsol uygulamasında olduğu gibi her şey `Main` metodunda başlar.
*   `CreateHostBuilder` metodu; uygulamanın barındırma (hosting) ayarlarını yapar, **Kestrel** adlı inanılmaz hızlı dahili web sunucusunu ayağa kaldırır ve uygulamanın asıl kurallarını belirleyecek olan `Startup.cs` dosyasını sisteme tanıtır.

## 3. Startup.cs (Uygulamanın Kalbi ve Servis Merkezi)
Uygulamanın çalışmasını sağlayan en kritik yapılandırma dosyasıdır. İki ana görevi vardır:
1.  **ConfigureServices:** Uygulamanın veritabanı bağlantıları, dış servisleri veya özel nesneleri bu metod içerisinde IoC Container'a (Bağımlılık Havuzu) eklenir. (Sorumluluk: Dependency Injection).
2.  **Configure:** Gelen bir HTTP isteğinin (Request) sunucuda hangi filtrelerden (Middleware) geçeceğini sırasıyla belirleyen İstek Hattıdır (Pipeline).

## 4. appsettings.json ve Hard-Coded (Gömülü Kod) Problemi
Yazılım mühendisliğinde veritabanı bağlantı metni (Connection String), API anahtarları veya loglama ayarları gibi dinamik değerleri doğrudan C# kodunun (Örn: Controller'ın) içine yazmak (Hard-coding) büyük bir hatadır.
*   **Neden Hatalıdır?** Veritabanı şifresi değiştiğinde, eğer şifre koda gömülüyse tüm projenin yeniden derlenmesi (Re-build) ve sunucuya tekrar yüklenmesi (Deploy) gerekir.
*   **Çözüm:** Tüm bu dinamik ayarlar `appsettings.json` gibi harici dosyalarda tutulur. Böylece kod derlendikten sonra bile, sunucuya hiç dokunmadan sadece bir metin (.json) dosyasını güncelleyerek sistemin davranışını değiştirebilirsiniz (Bakım maliyeti düşer, Çevresel Bağımsızlık sağlanır).
