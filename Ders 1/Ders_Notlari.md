# Ders 1: Temel MVC İskeleti ve Katman Soyutlaması

## Senaryo 1: Temel MVC İskeleti (ASP.NET Core 5.0)

**Standart MVC Dizin Yapısı:**
ASP.NET Core'da standart bir MVC projesi, sorumlulukların ayrılması (Separation of Concerns) prensibine göre belirli klasörlere bölünür. Temel dizin yapısı şu şekildedir:
*   `Controllers/`: HTTP isteklerini karşılayan ve iş mantığını yönlendiren sınıf dosyalarını barındırır (örn: `HomeController.cs`).
*   `Models/`: Uygulamanın veri yapılarını, iş kurallarını veya View'lara taşınacak veri modellerini (ViewModel) barındırır.
*   `Views/`: Kullanıcı arayüzünü oluşturan HTML ve C# kodlarının birleştiği Razor `.cshtml` dosyalarını barındırır.
*   `wwwroot/`: CSS, JavaScript, resimler gibi dışarıya açık statik dosyaların (istemci tarafı) tutulduğu klasördür.
*   `Startup.cs`: Uygulama servislerinin (DI) ve HTTP istek hattının (pipeline) yapılandırıldığı ana sınıftır.

## Senaryo 2: Katman Soyutlaması (Öğrenci Listeleme Senaryosu)

Katmanların birbirinden izole edilmesi; **View**'un verinin nereden geldiğini bilmemesi, **Controller**'ın veritabanı işlemlerine karışmaması ve **Model/Service** katmanının HTTP veya arayüz süreçlerinden tamamen bağımsız olması demektir.

1.  **Model Katmanı (Domain Entity):** Bağımsızdır, sadece veri yapısını tanımlar (`Student.cs`).
2.  **Servis/Soyutlama Katmanı (Interface):** Controller, verinin nereden (Veritabanı, API, XML vs.) geleceğini bilmez, sadece bu arayüzle konuşur (`IStudentService.cs`).
3.  **View Model (Görünüm Modeli):** Veritabanı modelini doğrudan View'a göndermek yerine, sadece ekranda gösterilecek verileri taşıyan özel bir sınıftır (`StudentListViewModel.cs`).
4.  **Controller Katmanı:** Sadece trafiği yönetir. Servisten veriyi ister, ViewModel'e dönüştürüp View'a aktarır (`StudentController.cs`).
5.  **View Katmanı:** Sadece ekrana çizmeyi bilir. Verinin SQL'den mi yoksa hafızadan mı geldiğinden habersizdir (`Index.cshtml`).
