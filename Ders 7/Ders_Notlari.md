# Ders 7: ASP.NET Core Sunucu (Web Server) Çeşitleri ve Barındırma Stratejileri

Modern ASP.NET Core uygulamaları, performansı ve esnekliği (cross-platform desteğini) sağlayabilmek adına klasik ASP.NET'ten çok daha farklı ve modüler bir sunucu mimarisine (hosting strategy) sahiptir.

## 1. Kestrel: Uygulamanın Kalbindeki Uç Sunucu (Edge Server)
*   **Kestrel Nedir?** ASP.NET Core'un içerisine dahili (built-in) olarak gömülü gelen, platform bağımsız (Windows, Linux, macOS'ta çalışabilen), inanılmaz hızlı ve hafif bir web sunucusudur.
*   **Mühendislik Kısıtlaması:** Kestrel, kodu saniyeler içinde ayağa kaldırıp çalıştırmak için mükemmeldir. Ancak güvenlik duvarı yönetimi (WAF), port yönlendirme, yük dengeleme (Load Balancing) ve SSL sonlandırması (SSL termination) gibi karmaşık internet süreçleri için tasarlanmamıştır. Bu nedenle Kestrel, canlı ortamlarda (Production) internete doğrudan açık bir uç sunucu olarak tek başına bırakılmaz.

## 2. Ters Vekil Sunucu (Reverse Proxy) İhtiyacı: IIS, Nginx ve Apache
Yukarıda bahsedilen güvenlik ve yönetim açıklarını kapatmak için mimari bir tasarım kalıbı olan **Reverse Proxy (Ters Vekil)** devreye girer.
*   **Çalışma Mantığı:** İnternetten gelen HTTP istekleri doğrudan uygulamanın çalıştığı Kestrel sunucusuna ulaşmaz. İstekleri önce en önde duran devasa ve güvenli vekil sunucular (Windows için **IIS**, Linux için **Nginx** veya **Apache**) karşılar.
*   **Avantajı:** Nginx veya IIS, isteği filtreler, güvenliğini doğrular, SSL sertifikasını çözer ve sadece güvenilir, temiz trafiği arka planda çalışan Kestrel'e (iç ağ üzerinden) iletir. Kestrel ise sadece C# kodlarını hızlıca derleyip sonucu geri vekil sunucuya teslim etmekle uğraşır.

## 3. HTTP.sys: Windows'a Özgü Çekirdek Sunucusu
*   Eğer uygulamanız kesinlikle sadece Windows ortamında çalışacaksa ve Kestrel'e güçlü bir alternatif arıyorsanız `HTTP.sys` kullanılır. 
*   **Farkı:** Doğrudan Windows'un çekirdeğinde (Kernel mode) çalıştığı için ters vekil sunucuya (IIS) ihtiyaç duymadan internete açılabilir. Özellikle Windows Kimlik Doğrulaması (Windows Auth) gereken kurumsal (Intranet) mimarilerde tercih edilir.

## 4. Docker: Sanallaştırma ve Mikroservis Platformu
*   **Docker Bir Sunucu Değildir:** Yaygın bir yanılgı olsa da Docker, Kestrel veya IIS gibi bir HTTP sunucusu değildir. 
*   **Rolü:** Docker bir *Konteynerleştirme (Containerization)* platformudur. ASP.NET Core uygulamanızı, Kestrel sunucunuzu, framework dosyalarınızı ve gerekli tüm işletim sistemi kütüphanelerini "Container" adı verilen izole bir kutunun içine hapseder. 
*   **Avantajı:** "Benim bilgisayarımda çalışıyordu, sunucuda çalışmıyor" sorununu yok eder. Konteyner nereye giderse (AWS, Azure, Local) uygulama o ortamda aynı Kestrel yapılandırmasıyla hatasız ayağa kalkar. Mikroservis mimarisinin vazgeçilmezidir.
