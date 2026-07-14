# Ders 14: Boş Bir Projeyi MVC Mimarisine Dönüştürme ve "Convention over Configuration"

ASP.NET Core'da "Empty" (Boş) bir proje şablonuyla başladığınızda sistem sadece bir Kestrel sunucusu ve düz metin dönebilen basit bir yapıya sahiptir. Bu iskeleti devasa bir MVC mimarisine dönüştürmek, belirli konfigürasyonlar ve kurallar zinciri gerektirir.

## 1. MVC Servislerinin Enjeksiyonu (Dependency Injection)
Sistemin "Controller" sınıflarını tanıması ve "View" motorunu (Razor) çalıştırabilmesi için bu yeteneklerin IoC (Inversion of Control) konteynerine eklenmesi gerekir.
*   **`AddControllersWithViews()` Servisi:** `Startup.cs` içerisindeki `ConfigureServices` metoduna bu kodu yazdığınızda, ASP.NET Core çekirdeğine şunu söylemiş olursunuz: *"Benim uygulamamda Controller'lar olacak, bunlar tarayıcıya saf JSON değil, View (HTML) döndürecek. MVC mimarisi için gereken tüm kütüphaneleri belleğe (RAM) yükle."*

## 2. Convention over Configuration (Konfigürasyon Yerine Gelenek/Kural Prensibi)
Microsoft, yazılımcıları sürekli uzun ayarlar (konfigürasyonlar) yapmaktan kurtarmak için **"Gelenek (Convention)"** adı verilen altın kurallar dizisi yaratmıştır. Sistemin çalışması için bazı isimlendirme standartlarına uymak "zorunludur":
*   **Controller İsimlendirmesi:** Yazdığınız bir sınıfın gerçekten Controller olabilmesi için adının sonuna `Controller` kelimesi gelmelidir (Örn: `ProductController`) ve Microsoft'un temel `Controller` sınıfından kalıtım (inherit) almalıdır. Aksi halde sistem onu sıradan bir C# sınıfı sanır ve HTTP isteklerini ona yönlendirmez.
*   **View Klasör Hiyerarşisi:** View dosyalarının nerede duracağı kesin kurallara bağlıdır. Sistem, HTML dosyalarını rastgele aramaz. Ana dizindeki `Views` klasörünün içinde, ilgili Controller'ın adıyla eşleşen bir alt klasör arar (Örn: `Views/Product/`). Ve onun içinde de ilgili Action ile eşleşen bir dosya arar.

## 3. `return View();` Mekanizması Nasıl Çalışır?
Controller içerisindeki `GetProducts()` isimli Action metodunuzun sonunda `return View();` kodunu çağırdığınızda arka planda kusursuz bir arama motoru çalışır:
1.  Sistem önce metodun adını okur: `"Demek ki Action adım GetProducts."`
2.  Sistem sınıfın adını okur: `"Demek ki Controller adım Product."`
3.  Ardından View Engine (Razor Motoru) devreye girer ve fiziksel dizinlerde tam olarak şu yolu arar: 
    👉 `Views/Product/GetProducts.cshtml`
4.  Eğer bu dizinde bu isimde bir dosya bulursa, Controller'daki veriyi o dosyaya basar ve HTML olarak ekrana çizer. Bulamazsa hata fırlatır. İşte bu mühendislik tasarımına **Convention over Configuration** denir; siz klasör yolunu uzun uzun yazmazsınız, kurallara uyduğunuz için sistem onu kendi bulur.
