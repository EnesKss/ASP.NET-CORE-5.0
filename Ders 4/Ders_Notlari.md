# Ders 4: Web Mimarisinin Temelleri ve Request-Response Döngüsü

## 1. Web Mimarisinin Temel Yapıtaşları
Modern web mimarisi temel olarak üç ana aktörün birbiriyle olan iletişimine dayanır:
*   **User (Kullanıcı):** Sistemin en ucundaki, ekrana bakıp etkileşime geçen gerçek insandır.
*   **Client (İstemci):** Kullanıcı ile sunucu arasındaki köprüyü kuran yazılımdır (Chrome, Safari, Mobil Uygulama vb.). İşlevi, kullanıcının eylemlerini sunucuya iletmek ve sunucudan gelen yanıtı (HTML, JSON) kullanıcının anlayacağı görsel bir formata çevirmektir (Render).
*   **Server / Hosting (Sunucu):** Kesintisiz (7/24) internete bağlı olan, güçlü donanımlara sahip ve Client'tan gelen istekleri karşılayıp işleyen (Business Logic) ana bilgisayardır.

## 2. IP ve Domain Kavramları (DNS Yönlendirmesi)
İnternetteki her cihazın (sunucunun) benzersiz bir fiziksel adresi vardır ve buna **IP Adresi** (örn: `192.168.1.15`) denir.
*   **Domain (Alan Adı) - Soyutlama (Abstraction):** İnsanların IP adreslerini ezberlemesi imkansızdır. Bu nedenle IP adreslerinin üzerine insan diline yatkın (örn: `google.com`) maskeler geçirilmiştir. Yazılım terminolojisinde bu duruma karmaşıklığı gizleyen "soyutlama" (abstraction) denir.
*   **DNS (Domain Name System):** İstemci tarayıcıya `domain.com` yazdığında, tarayıcı arka planda DNS adı verilen devasa "internet telefon rehberine" gider ve *"Bu alan adının IP adresi nedir?"* diye sorar. Öğrendiği IP adresini kullanarak doğrudan sunucuyla iletişime geçer (Yönlendirme).

## 3. İnternetin Felsefesi: Request (İstek) ve Response (Yanıt) Döngüsü
Tüm internet ekosistemi basit bir İstek-Yanıt döngüsüyle çalışır. Bu döngü şu adımlarla gerçekleşir:
1.  **Tetikleme:** Kullanıcı tarayıcıya URL girer veya bir butona tıklar.
2.  **Request (İstek) Gönderimi:** Client, hedef Sunucuya ağ protokolleri üzerinden bir HTTP İstek (Request) paketi yollar. Bu paket ne istendiğini (GET, POST) ve kimin istediğini içerir.
3.  **Sunucuda İşleme (Processing):** Sunucudaki web sunucusu (ASP.NET Core için Kestrel) isteği yakalar ve MVC mimarisinin içindeki ilgili `Controller` katmanına ulaştırır.
4.  **Result (Sonuç) Üretimi:** Controller veritabanına bağlanır, iş mantığını çalıştırır ve bellekte bir işlem sonucu (Result) elde eder.
5.  **Response (Yanıt) Dönüşü:** Elde edilen Sonuç (Result), HTML veya JSON formatına dönüştürülerek HTTP Response paketine konulur ve İstemciye (Client) geri fırlatılır. Döngü tamamlanır. Client gelen veriyi ekranda çizer.
