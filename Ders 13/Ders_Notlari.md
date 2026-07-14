# Ders 13: ASP.NET Core MVC Request Pipeline (İstek Yaşam Döngüsü)

Bir kullanıcının tarayıcıya (Client) adres yazıp Enter'a basmasıyla ekranda sayfanın açılması arasında geçen süre milisaniyeler sürer. Ancak arka planda, yazılım mühendisliğinin başyapıtlarından biri olan kusursuz bir "Request Pipeline" (İstek Hattı) süreci işler.

## İsteğin (Request) Mimari Yaşam Döngüsü

**1. Kestrel Sunucusu ve Middleware (Ara Yazılım) Hattı:**
Tarayıcıdan yola çıkan HTTP isteği (Request), uygulamanın kapısındaki Kestrel sunucusuna çarpar. Sunucu bu isteği içeri alır ve fabrikadaki bir üretim bandına (Pipeline) oturtur. İstek sırasıyla ara yazılımlardan (Middleware) geçer. Örneğin; hata yakalayıcıdan geçer, statik dosya (CSS/JS) denetleyicisinden geçer.

**2. Routing (Yönlendirme) ve URL Çözümleme:**
İstek üretim bandında ilerlerken `UseRouting` mekanizmasına gelir. Bu sistem, gelen URL'i bir dedektif gibi parçalar (URL Parsing). Gelen adres `/Product/Detail/5` ise sistem şunu tespit eder: "Bu istek 'Product' isimli Controller'ın içindeki 'Detail' isimli Action metoduna gitmek istiyor ve yanında '5' IDsini taşıyor." Hedeflenen bu varış noktasına **Endpoint** denir.

**3. Controller'ın İnşa Edilmesi:**
Uygulama varış noktasını (Endpoint) anladığı an, Dependency Injection (Bağımlılık Havuzu) mekanizması devreye girer. Hafızada `ProductController` sınıfının yepyeni bir örneğini (Instance) sıfırdan üretir ve isteği bu sınıfa teslim eder.

**4. İş Mantığı (Action) ve Model Katmanı:**
Controller, kendisine gelen `Detail(int id)` metodunu tetikler. İş kurallarını çalıştırır, 5 numaralı ürünün bilgisini almak için **Model** katmanına (Veritabanına) iner. Veriyi güvenle alır ve bir obje haline getirir.

**5. Yanıtın (Result) Kararlaştırılması:**
Controller işlemi bitirince bir karar verir:
*   *API ise:* Doğrudan bu ham objeyi alır ve "Sana JSON dönüyorum" diyerek `Ok(data)` ile geriye fırlatır.
*   *MVC ise:* Bu ham objeyi alır ve "Bunu ekranda çizebilecek bir şablona ihtiyacım var" diyerek ilgili **View** (HTML) dosyasına fırlatır `return View(data)`.

**6. View'un Çizilmesi (Render) ve Yanıtın (Response) Dönüşü:**
Razor Engine (Görünüm Motoru), Modelden gelen saf veriyi HTML etiketlerinin içine gömer (Render) ve görsel bir sayfa üretir. Bu sayfa, üretim bandından (Middleware) ters yönde çıkarak bir HTTP Yanıt (Response) paketine dönüşür ve İstemciye (Client) geri yollanır. Ekranda site açılır.
