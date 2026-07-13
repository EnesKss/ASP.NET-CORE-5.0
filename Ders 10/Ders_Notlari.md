# Ders 10: Model-View-Controller (MVC) Tasarım Deseni ve Yaşam Döngüsü

ASP.NET Core mimarisinin omurgası olan MVC, web dünyasındaki en popüler ve temiz kod yazmayı sağlayan yazılım mimarilerinden biridir.

## 1. MVC Bir Microsoft İcadı Değildir
Sektörde sıkça düşülen bir yanılgı, MVC'nin Microsoft'a veya ASP.NET'e ait bir teknoloji olduğunun sanılmasıdır. **MVC (Model-View-Controller)**, aslında 1970'lerde ortaya çıkmış, programlama dilinden ve teknolojiden tamamen bağımsız evrensel bir **Tasarım Deseni (Design Pattern)**'dir. Java (Spring), Python (Django), PHP (Laravel) gibi teknolojiler de MVC desenini kullanır. Microsoft, sadece bu mimariyi kendi ASP.NET Core altyapısına kusursuz bir şekilde entegre etmiştir (uyarlamıştır).

## 2. Separation of Concerns (Sorumlulukların Ayrılığı)
MVC mimarisinin temel amacı kod karmaşasını (Spaghetti Code) engellemek ve "Separation of Concerns" ilkesini uygulamaktır. Proje fiziksel ve mantıksal olarak 3 ana parçaya bölünür:
*   **Model (Veri ve İş Mantığı):** Uygulamanın veritabanı ile konuştuğu, verilerin (nesnelerin) tanımlandığı ve iş kurallarının (hesaplamalar, doğrulamalar) çalıştığı katmandır. Görsellikle hiçbir ilgisi yoktur.
*   **View (Sunum ve Arayüz):** Son kullanıcının ekranda gördüğü (HTML, CSS, JS) kısımdır. Sadece kendine verilen veriyi ekrana çizmeyi (Render) bilir. Verinin nereden, hangi SQL sorgusuyla geldiğini asla umursamaz.
*   **Controller (Orkestrasyon ve İstek Karşılama):** Sistemin beynidir. İstemciden (Client) gelen HTTP isteklerini yakalar. Gerekirse Model'e gidip veriyi alır, işler ve sonucu (Result) gösterilmek üzere View'a fırlatır.

## 3. İstemci İsteği (Request) Yaşam Döngüsü - Adım Adım
Bir kullanıcı tarayıcıya `site.com/Employee/Index` yazdığında arka planda şu mimari yaşam döngüsü çalışır:
1.  **Request (İstek) Gelir:** Kullanıcının isteği sunucuya ulaşır. Yönlendirme (Routing) mekanizması bu isteği yakalayıp doğrudan `EmployeeController` içindeki `Index` metoduna (Action) teslim eder.
2.  **Controller Harekete Geçer:** Controller, "Benden personel listesi isteniyor" der.
3.  **Model'den Veri İstenir:** Controller, Model katmanına (veya Veritabanına) gidip "Bana tüm personelleri ver" der. Model veriyi çeker ve Controller'a nesne (Object) olarak geri verir.
4.  **Verinin View'a Aktarılması:** Controller aldığı bu ham veriyi (Listeyi), `return View(data)` koduyla beraber ilgili View katmanına (HTML Şablonuna) fırlatır.
5.  **View'un Çizilmesi (Render):** View katmanı (Razor Engine), Controller'dan gelen listeyi okur, `foreach` döngüsüyle HTML tablolarının (TR, TD) içine gömer ve görsel bir sayfa oluşturur.
6.  **Response (Yanıt) Dönüşü:** Çizimi biten bu HTML sayfası, HTTP Response paketi olarak İstemciye (Client) geri gönderilir. Tarayıcı da bu sonucu kullanıcıya gösterir. Döngü tamamlanır.
