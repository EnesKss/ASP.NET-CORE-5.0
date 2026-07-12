# Ders 9: Olay Tabanlı Web Geliştirme (Event-Driven) ve Klasik ASP.NET WebForms

ASP.NET Core'un benimsediği modern MVC mimarisine ve temiz kod standartlarına geçmeden önce, Microsoft'un web dünyasında uzun yıllar hüküm süren eski "Olay Tabanlı Mimariyi (Event-Driven)" ve bu mimarinin neden terk edildiğini anlamak mühendislik vizyonu açısından çok kritiktir.

## 1. Olay Tabanlı Web Mimarisinin Çalışma Prensibi
Olay tabanlı (Event-Driven) yaklaşım, özellikle **ASP.NET WebForms** teknolojisiyle web dünyasına taşınmıştır. Bu mimarinin temel felsefesi; bir masaüstü uygulaması (Windows Forms) geliştiriyormuş gibi sürükle-bırak yöntemiyle web sitesi yapmaktır.
*   **Olay (Event):** Kullanıcının arayüz (UI) üzerinde gerçekleştirdiği herhangi bir eylemdir. Örneğin: Ekranda gördüğü bir `btnKaydet` butonuna fiziksel olarak tıklaması.
*   **İş/Operasyon (Action):** Olay gerçekleştiği anda arka plandaki "Code-Behind" dosyasında anında tetiklenen (trigger) C# kodudur.
*   **Süreç:** `btnKaydet_Click` olayı tetiklenir tetiklenmez, arkadaki C# kodu çalışır ve veritabanına `INSERT` işlemi gerçekleştirilir.

## 2. Tasarım ve Kodun İç İçe Geçmesi: Yüksek Bakım Maliyeti (Spaghetti Code)
WebForms mimarisinde HTML elemanları sıradan etiketler değil, `<asp:Button>` gibi özel sunucu (server) kontrolleri olarak tasarlanmıştı. 
*   **Görünmez Bağlar:** Ekrandaki HTML elemanı ile arka plandaki C# (Code-Behind) dosyası birbirine sıkı sıkıya ve fiziksel olarak bağlıydı (Tight Coupling). HTML dosyasındaki bir butonun ID'si silindiğinde arka plandaki C# kodu anında derleme hatası veriyordu.
*   **Mühendislik Çöküşü:** Zamanla veritabanı bağlantı kodları, hesaplama algoritmaları (Business Logic) ve ekrandaki butonun rengini değiştiren UI kodları aynı `.cs` dosyasının içine yığılmaya başladı.
*   **Spaghetti Code:** Kod ve tasarım o kadar iç içe geçti ki; okunması, yeni bir yazılımcıya devredilmesi veya yeni bir özellik eklenmesi neredeyse imkansız hale geldi. Yüksek bakım maliyetleri doğdu.

## 3. Microsoft Neden Bu Yaklaşımdan Desteğini Çekti?
Microsoft, bu hantal yapıyı terk edip ASP.NET Core ile tamamen MVC (Model-View-Controller) mimarisine odaklanmıştır. Bunun ana sebepleri temel yazılım mühendisliği prensipleridir:

*   **Separation of Concerns (Sorumlulukların Ayrılığı) İhlali:** 
    İyi bir yazılım mimarisinde; Görünüm (Frontend/UI) verinin nereden geldiğini bilmemeli, Kod (Backend/Controller) ise verinin sayfada nasıl renklendirildiğini umursamamalıdır. WebForms mimarisi bu ayrımı tamamen yok saydığı için büyük kurumsal projelerde çökmüştür.

*   **Ağ Yükü ve ViewState Problemi:**
    Masaüstü hissiyatını web'de yaşatmak için her tıklamada (Postback) sayfanın o anki tüm durumu şifrelenip devasa bir metin (ViewState) halinde sunucuya gidip geliyordu. Bu durum, sunucu-istemci arasındaki ağ (network) trafiğini gereksiz yere boğdu ve performansı bitirdi.

*   **Test Edilemezlik (Unit Test Eksikliği):**
    UI (Arayüz) ile İş Mantığı (Business Logic) birbirinden ayrılamadığı için; sadece hesaplama yapan bir metodu izole edip otomatik birim testi (Unit Test) yazmak mühendislik açısından neredeyse imkansızdı.

**Sonuç:** Bu nedenlerden ötürü Microsoft, olay tabanlı (butona tıkla - kod çalışsın) yapıyı terk etmiş; istek tabanlı (HTTP Request - Response) ve katmanların tamamen izole edildiği modern **ASP.NET Core MVC** mimarisine geçiş yapmıştır.
