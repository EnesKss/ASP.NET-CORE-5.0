# Ders 3: ASP.NET Core 5.0 Dizin Yapısı ve Çekirdek Dosyaların Mimarisi

ASP.NET Core 5.0 projeleri, modülerliği ve performansı merkeze alan, sadeleştirilmiş bir proje yapısıyla gelir. Bir uygulamanın nasıl çalıştığını anlamak için bu dizinlerin ve yapılandırma dosyalarının görevlerini yazılım mühendisliği prensipleri çerçevesinde kavramak esastır.

## 1. Uygulamanın Giriş Noktası: `Program.cs` ve Kestrel
ASP.NET Core uygulamaları özünde birer Console (Konsol) uygulamasıdır. Her konsol uygulamasında olduğu gibi giriş noktası `Program.cs` içerisindeki `Main` metodudur.
*   **Kestrel Sunucusu:** Bu dosya, Microsoft tarafından geliştirilen, çapraz platform destekli (cross-platform) ve inanılmaz hızlı, dahili web sunucusu olan **Kestrel**'i ayağa kaldırır. 
*   **Hosting (Barındırma) Modeli:** `IHostBuilder` arayüzü sayesinde uygulamanın üzerinde çalışacağı ortam (environment), web sunucusu ayarları ve diğer çekirdek konfigürasyonlar (appsettings entegrasyonu vb.) boot (başlatma) anında yapılandırılır.

## 2. Uygulamanın Kalbi: `Startup.cs`
`Program.cs` sunucuyu ayağa kaldırırken, uygulamanın asıl iş mantığının, servislerin ve HTTP rotalarının belirlendiği merkez `Startup.cs` sınıfıdır. Bu dosya iki temel metoda bölünerek katı bir **Separation of Concerns (Sorumlulukların Ayrılığı)** prensibi uygular:

*   **`ConfigureServices` (IoC Container & Servis Kaydı):**
    Uygulamanın ihtiyaç duyduğu dış veya iç bağımlılıkların (veritabanı bağlantıları, dış servisler, kimlik doğrulama modülleri) sisteme tanıtıldığı (register edildiği) yerdir.
    *Yazılım Prensibi:* Burada **Inversion of Control (IoC)** ve **Dependency Injection (Bağımlılık Enjeksiyonu)** prensipleri devrededir. Sınıfların kendi nesnelerini üretmesi yerine, tüm bağımlılıklar merkezi bir konteynerde yönetilir.

*   **`Configure` (HTTP Request Pipeline & Middleware):**
    İstemciden (tarayıcıdan) gelen bir HTTP isteğinin, sunucuda hangi aşamalardan (ara yazılımlardan) geçerek yanıt (Response) üreteceğini belirlediğimiz hattan (pipeline) sorumludur.
    *Yazılım Prensibi:* Burada **Chain of Responsibility (Sorumluluk Zinciri)** tasarım deseni uygulanır. İstek, sıraya dizilmiş Middleware'lerden (ara yazılım) sırasıyla geçer (örneğin: önce Yetkilendirme, sonra Yönlendirme).

## 3. Konfigürasyon Yönetimi: `appsettings.json`
Uygulamaya ait veritabanı bağlantı metinleri (connection strings), loglama seviyeleri veya API anahtarları gibi dinamik değerlerin tutulduğu dosyadır.
*   **Ayrıştırma (Separation):** Hard-coded (koda gömülü) verilerin önüne geçerek konfigürasyon ile kod tabanını birbirinden ayırır.
*   **Ortam Bağımsızlığı (Environment-based):** `appsettings.Development.json` gibi varyasyonlarla uygulamanın test ve canlı ortam yapılandırmalarının birbirinden izole (izolasyon) edilmesini sağlar.

## 4. Statik Dosya Yönetimi: `wwwroot` Dizin
CSS, JavaScript, resim ve ikon gibi istemci (client-side) tarafında doğrudan tüketilecek statik dosyaların tutulduğu, dışarıya açık tek dizindir.
*   **Güvenlik ve Performans:** Uygulamanın C# (.cs) dosyalarına dışarıdan tarayıcı üzerinden asla erişilemez. Tarayıcı sadece `wwwroot` dizinini görebilir. Ayrıca bu dosyalar, gereksiz arka plan işlemlerine (controller/action) girmeden Middleware üzerinden çok daha hızlı bir şekilde istemciye sunulur (StaticFiles Middleware).
