# Ders 11: Application Programming Interface (API) Yaklaşımı ve Arayüzsüz (Headless) Mimari

Geleneksel MVC mimarisinde sunucu tarafı bir "HTML Şablonu (View)" oluşturup bunu tarayıcıya yollarken; modern sistemlerin birbirleriyle entegre çalışması (Örn: Mobil uygulamalar, IoT cihazları) bambaşka bir altyapı gerektirir. Bu altyapının kalbi **API**'dir.

## 1. API Sadece Bir "Web Uygulaması" Değildir
API (Application Programming Interface), sadece internet (HTTP) üzerinden çalışan bir teknoloji değildir. En temel yazılım mühendisliği tanımıyla API; iki farklı donanımın, işletim sisteminin veya yazılımın birbirleriyle nasıl iletişim kuracaklarını belirleyen **evrensel bir arayüzdür**.
*   Örneğin; C# ile yazdığınız bir masaüstü uygulamasının bilgisayarınızın web kamerasını açabilmesi, işletim sisteminin sunduğu (Windows API) donanım API'leri sayesinde mümkündür.

## 2. İstemci ve Sunucu Arasında Bir "Sözleşme/Kontrat" (Contract)
"Web API" konseptine döndüğümüzde, API aslında İstemci (Client) ile Sunucu (Server) arasında imzalanmış katı bir **Sözleşmedir (Contract)**.
*   **Sunucu der ki:** *"Eğer bana `api/products` adresinden, HTTP POST fiiliyle, içinde sadece 'Name' ve 'Price' alanları olan bir JSON paketi gönderirsen (Sözleşme Şartı); ben de sana bu ürünü veritabanına ekleyeceğimi ve karşılığında HTTP 201 (Created) koduyla birlikte ürünün yeni ID'sini döneceğimi garanti ediyorum."*
*   İstemci bu kuralların dışına çıkarsa (farklı format yollarsa) API sözleşmeyi ihlal sayar ve hata (400 Bad Request) döner.

## 3. Arayüzsüz (Headless) Mimari ve Çoklu Platform Desteği
Web API'leri asla HTML, CSS veya görsel bir buton (View) üretmezler. Onlar **arayüzsüz (headless) saf veri (JSON/XML) kaynaklarıdır**. Bu durum muazzam bir esneklik sağlar:
*   MVC mimarisinde bir web siteniz varsa, aynı kodları mobil uygulama için kullanamazsınız (Çünkü mobil uygulama HTML değil, iOS/Android'e özgü diller anlar).
*   Ancak merkezde tek bir **ASP.NET Core Web API**'niz varsa; 
    1.  **Web Siteniz (React/Angular)** bu API'ye bağlanıp JSON çekebilir.
    2.  Aynı anda bir **iOS/Android Mobil Uygulaması** aynı API'den aynı JSON'ı çekip kendi arayüzünde çizebilir.
    3.  Aynı anda akıllı bir buzdolabı **(IoT - Nesnelerin İnterneti)** aynı API'den sipariş durumu çekebilir.
    4.  Aynı anda şirketin diğer **Mikroservisleri** bu API ile sunucudan sunucuya arka planda haberleşebilir.

İşte modern yazılım dünyasının (ve mobil çağın) tamamen Web API'ler üzerine inşa edilmesinin sebebi bu inanılmaz platform bağımsızlığıdır.
