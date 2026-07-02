# Ders 6: RESTful HTTP Metotları ve İleri Seviye CRUD Operasyonları

Modern web mimarisinde (özellikle RESTful API'lerde), İstemci ile Sunucu arasındaki iletişim sadece veri taşımakla kalmaz, aynı zamanda veriye ne yapılacağını da (niyeti) HTTP metotları (fiilleri) aracılığıyla bildirir.

## 1. HTTP Metotlarının Veri Tabanı (CRUD/SQL) Karşılıkları
*   **GET:** `SELECT` - Veri okuma.
*   **POST:** `INSERT` - Yeni kayıt ekleme.
*   **PUT:** `UPDATE` - Bütünsel güncelleme.
*   **PATCH:** `UPDATE` - Kısmi güncelleme.
*   **DELETE:** `DELETE` - Kayıt silme.

## 2. PUT ve PATCH Arasındaki Mühendislik ve Performans Farkı
Her iki metot da veritabanında "Update" işlemi yapar ancak metodolojileri tamamen farklıdır:
*   **PUT (Bütünsel / Tam Güncelleme):** Bir kaydın üzerine tamamen yeni bir kayıt yazmak (ezmek) gibidir. İstemci, sadece değişen alanı değil, objenin tüm alanlarını (değişmeyenler dahil) sunucuya göndermek zorundadır. Sunucu gelen objeyi alır ve eski objenin üzerine koyar.
*   **PATCH (Kısmi Güncelleme):** Objenin sadece değişmesi gereken belirli alanlarını günceller. İstemci sadece "şu alanın değerini şununla değiştir" şeklinde küçük bir paket yollar.
    *   *Performans:* Özellikle çok sütunlu, devasa veri modellerinde sadece tek bir harf değişikliği için tüm objeyi PUT ile göndermek ağ (network) trafiğini gereksiz yorar. PATCH, sadece değişen veriyi taşıdığı için bant genişliği (bandwidth) açısından çok daha performanslıdır.

## 3. Mimari Açıdan Silme Mantığı: Hard Delete vs. Soft Delete
*   **Hard Delete (Fiziksel Silme - DELETE Metodu):** Verinin veritabanından kalıcı olarak (SQL'deki `DELETE FROM` komutu ile) uçurulmasıdır. Geri dönüşü yoktur. Veritabanı bütünlüğünü (foreign key constraint) riske atabilir.
*   **Soft Delete (Mantıksal/Kısmi Silme - PUT/PATCH Metodu):** Modern yazılım mimarilerinde veriler nadiren gerçekten silinir. Bunun yerine verinin içerisindeki durum bayrağı (Status Flag) değiştirilir (Örn: `IsActive = false` veya `IsDeleted = true`). 
    *   *Mimari Ayrım:* Soft Delete işlemi aslında bir "silme" işlemi değil, veritabanındaki bir alanın "güncellenmesi" işlemidir. Bu yüzden mimari standartlara göre Soft Delete işlemleri `HTTP DELETE` ile değil, veriyi güncelleyen `HTTP PUT` veya `HTTP PATCH` ile yapılmalıdır.
