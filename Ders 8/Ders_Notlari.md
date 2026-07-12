# Ders 8: Backend ve Frontend Kavramları (Rollerin Ayrımı)

Yazılım mühendisliğinde "Separation of Concerns" (Sorumlulukların Ayrılığı) prensibinin en belirgin şekilde görüldüğü yer Backend ve Frontend ayrımıdır.

## 1. Yanlış Bilinenler ve Asıl Ayrım
Sektörde sıkça düşülen bir hata şudur: *"Backend karmaşık algoritmalar yazılan zor kısımdır, Frontend ise sadece görsel çizimlerin yapıldığı kolay kısımdır."* Bu kesinlikle yanlıştır. Modern SPA (React, Angular vb.) mimarilerinde Frontend'de devasa bir iş mantığı (business logic) yatabilir.

**Asıl Mühendislik Ayrımı Şudur:**
*   **Backend (Veriyi Üreten):** Sistemin kalbidir. Ham veriyi veritabanından çeker, algoritmik iş kurallarından geçirir, güvenlik (Authentication) testlerini yapar ve sonucu saf "Veri (Data)" olarak dışarıya açar. Ekranı, tasarımı, kullanıcının bu veriyi nasıl göreceğini asla umursamaz.
*   **Frontend (Veriyi Tüketen ve Anlamlandıran):** Backend'in dışarıya açtığı o "saf ve çirkin" veri yığınını alır. Son kullanıcının (User) okuyup anlayabileceği butonlara, tablolara, grafiklere çevirir. Yani veriyi "anlamlandırır".

## 2. Aşçı ve Garson Metaforu
Bu ayrımı anlamanın en iyi yolu restoran benzetmesidir:
*   **Aşçı (Backend):** Mutfaktadır. Malzemeleri (Veritabanı) alır, belirli bir tarife (İş Kuralları / Business Logic) göre yemeği pişirir ve servis tabağına (JSON) koyup mutfağın teslimat penceresine bırakır. Aşçı müşteriyi görmez, yemeğin masada nasıl duracağını bilmez.
*   **Garson (Frontend):** Mutfaktan o yemeği alır. Müşterinin (User) önündeki masaya şık bir şekilde sunar, müşterinin şikayetlerini veya yeni siparişlerini (Tıklama, Form Doldurma) tekrar mutfağa taşır.

## 3. Mikroservislerde Rol Değişimi: "Frontend olan Backend"
Bir uygulamanın "Frontend" veya "Client (İstemci)" sayılabilmesi için illaki bir Chrome tarayıcısı veya HTML sayfası olması gerekmez. Eğer mikroservis mimarisindeyseniz;
*   **Örnek:** 'Fatura Servisi' (Backend), 'Müşteri Servisi'ne (Backend) HTTP isteği atıp müşteri bilgilerini çekiyorsa; o saniyelik iletişimde Fatura Servisi veriyi isteyen ve tüketen taraf olduğu için **Client / Frontend** rolüne bürünmüş olur. Yani bu kavramlar fiziksel değil, "iletişim yönüne" göre değişen mantıksal kavramlardır.
