# Ders 5: HTTP Protokolü ve Evrensel İletişim Dili

## 1. Yazılım Mimarisinde HTTP Protokolünün Yeri (Ortak Dil)
Yazılım ekosisteminde İstemci (Client - Örn: Android Telefon, Chrome Tarayıcı) ve Sunucu (Server - Örn: Linux tabanlı bir IIS/Kestrel makinesi) birbirinden tamamen farklı donanım yapılarına, işletim sistemlerine ve programlama dillerine sahip olabilir.
*   **Protokol Nedir?** Bu iki yabancı (farklı dilleri konuşan) sistemin birbiriyle pürüzsüzce iletişim kurmasını sağlayan **evrensel kurallar bütününe ve standart sözleşmeye (Contract)** protokol denir. 
*   HTTP (Hypertext Transfer Protocol), modern web mimarisinde Client ve Server'ın birbirine veri paketleri gönderirken "hangi zarfa koyacağı", "hangi başlıkları (header) ekleyeceği" ve "hangi dili konuşacağı" konusundaki kesin standarttır.

## 2. HTTP Fiilleri (Verbs) ve CRUD (Veritabanı) Karşılıkları
RESTful mimarinin temelini oluşturan HTTP metotları (fiilleri), aslında veritabanı dünyasındaki klasik **CRUD (Create, Read, Update, Delete)** operasyonlarının web üzerindeki standart yansımalarıdır:

*   **GET (CRUD: READ - Okuma):**
    *   *Amacı:* Sunucudan kaynak (veri) talep etmek içindir (Örn: Ürünleri listele, profili getir).
    *   *Mühendislik Notu:* Sadece okuma yaptığı için sunucudaki veriyi değiştirmez (Güvenlidir). Veriler genellikle URL üzerinden (Query String veya Route Data) taşınır.

*   **POST (CRUD: CREATE - Oluşturma):**
    *   *Amacı:* Sunucuya (ve veritabanına) yepyeni bir kaynak/veri eklemek için kullanılır (Örn: Yeni üye kaydı olmak, sepete ürün eklemek).
    *   *Mühendislik Notu:* Yeni oluşturulacak hassas veriler URL'de değil, HTTP isteğinin gövdesinde (HTTP Body) şifrelenmiş olarak taşınır.

*   **PUT (CRUD: UPDATE - Güncelleme):**
    *   *Amacı:* Sunucuda var olan bir kaynağı bütünüyle güncellemek veya değiştirmek için kullanılır (Örn: Kullanıcı profilindeki tüm bilgileri yenilemek).

*   **DELETE (CRUD: DELETE - Silme):**
    *   *Amacı:* Sunucudaki var olan bir kaynağı/veriyi kalıcı olarak silmek için kullanılır. Genellikle silinecek verinin ID'si URL üzerinden gönderilir.
