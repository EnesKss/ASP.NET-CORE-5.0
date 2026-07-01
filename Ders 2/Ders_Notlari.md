# Ders 2: ASP.NET Core Mimarisinin Temel Felsefesi ve Evrimi

## 1. ASP.NET Bir Programlama Dili Değildir
ASP.NET geliştiriciler arasında genellikle yanlış anlaşılarak bir programlama dili gibi algılanabilir. Ancak **ASP.NET bir dil değil, C# (veya F#, VB.NET) dilleri ile desteklenen güçlü bir web geliştirme mimarisidir (framework)**. Programlama mantığı, iş kuralları ve algoritmalar C# ile kurgulanırken; web ile iletişim, HTTP süreçleri ve istek yaşam döngüsü (request pipeline) ASP.NET Core mimarisi tarafından yönetilir.

## 2. Klasik ASP.NET'ten ASP.NET Core'a Evrim
Klasik ASP.NET'in (ve .NET Framework'ün) getirdiği kısıtlamalar aşılarak, ASP.NET Core ile tamamen baştan yazılan yepyeni bir vizyon ortaya konulmuştur:
*   **Açık Kaynak (Open Source):** Tüm kaynak kodları GitHub üzerinde açıktır. Arkasında sadece Microsoft değil, devasa bir topluluk desteği vardır. Bu sayede hatalar hızla çözülür ve mimari şeffaf, hızlı bir şekilde gelişir.
*   **Cross-platform (Çapraz Platform):** Klasik ASP.NET sadece Windows ve IIS sunucusuna bağımlıyken, ASP.NET Core; Windows, Linux ve macOS üzerinde kusursuz şekilde çalışabilen esnek bir yapıdadır. Bu durum sunucu maliyetlerini (özellikle Linux sunucular sayesinde) ciddi oranda düşürür.
*   **Yüksek Performans:** Gereksiz yüklerinden (legacy code) arındırılmış, hafifletilmiş (lightweight) yapısı sayesinde dünyanın en hızlı web framework'lerinden biri haline gelmiştir.

## 3. Modüler Altyapı ve Yazılım Mühendisliği Perspektifi
ASP.NET Core, "hepsi bir arada" (monolithic) ve hantal bir yapı yerine, **Modüler Altyapı** sunar. Yazılım mühendisliği terminolojisinde bu durum; uygulamanın küçük, bağımsız ve birbirine gevşek bağlı (loosely coupled) parçalardan oluşması anlamına gelir (Plug-and-play / Tak-çalıştır mimarisi). 
Sistemde varsayılan olarak hiçbir gereksiz yük barınmaz. Uygulama sadece ihtiyaç duyduğu kütüphaneleri (paketleri) bir araya getirerek (composition) kendi yapısını inşa eder. Bu durum memory (bellek) yönetimini ve uygulamanın ayağa kalkma (startup) hızını mükemmel seviyeye çıkarır.

## 4. Dahili (Built-in) Dependency Injection (IoC)
Önceki versiyonlarda dışarıdan üçüncü parti kütüphanelerle (Ninject, Autofac, StructureMap vb.) projeye dahil edilen Bağımlılık Enjeksiyonu, ASP.NET Core'un kalbine **dahili (built-in)** olarak yerleştirilmiştir. Her şey bu mimari etrafında şekillenir.
*   **Yönetilebilirlik:** Sınıflar arası sıkı bağlar (tight coupling) koparılır. Nesne üretim maliyetleri (new keyword'ünün kullanımı) ve bağımlılıkların yönetimi tamamen merkezileşerek IoC (Inversion of Control) konteynerine devredilir.
*   **Test Edilebilirlik:** Servisler birbirine doğrudan somut sınıflar (concrete classes) ile değil, arayüzler (interfaces) ile bağlı olduğu için Unit Test (Birim Testi) süreçleri çok daha kolay tasarlanır.
*   **Esneklik:** Bir servisin altyapısını değiştirmek istediğinizde (Örn: SQL Server'dan Oracle'a geçiş), tüm projeyi kod kod gezmek yerine sadece IoC konteynerindeki tek bir kayıt satırını değiştirmek yeterlidir.
