# Ders 18: View'a Birden Fazla Nesne Gönderimi (Tuple ve ViewModel)

ASP.NET Core MVC mimarisinde bir HTML sayfası (View) sadece ve sadece **tek bir `@model` (veri tipi)** kabul edecek şekilde tasarlanmıştır. Ancak gerçek dünyada bir ekranda aynı anda hem Kullanıcı bilgilerini (User nesnesi) hem de Şirket bilgilerini (Company nesnesi) göstermeniz gerekebilir. Bu problemi çözmenin mimari yolları şunlardır:

## 1. Zayıf Tipli (Weakly-Typed) Yaklaşım Neden Hatalıdır?
Birinci nesneyi `return View(user)` ile gönderip, ikinci nesneyi `ViewBag.Company = company` ile göndermek mümkündür. 
*   **Mühendislik Sorunu:** ViewBag ve ViewData derleme (compile-time) aşamasında hata fırlatmaz. Eğer HTML tarafında `ViewBag.Campany.Name` yazarsanız (Yazım hatası), sistem derlenir ancak çalışırken (Runtime) sayfa çöker. Intellisense (kod tamamlama) desteği yoktur. Bu yüzden yüksek bakım maliyeti (Maintainability) doğurur.

## 2. Kurumsal Çözüm: ViewModel Sınıfları
En doğru mühendislik yaklaşımıdır. İçerisinde hem `User` sınıfını hem de `Company` sınıfını Property (Özellik) olarak barındıran yepyeni bir `UserCompanyViewModel` sınıfı yazılır. View sadece bu sınıfı bekler (`@model UserCompanyViewModel`). Uzun vadede genişletilmesi ve bakımı çok kolaydır.

## 3. Pratik ve Güçlü Çözüm: Tuple (Demet) Nesneleri
Eğer sadece bir sayfa için gidip yeni bir ViewModel sınıfı (class) oluşturmak size zahmetli geliyorsa, C# 7.0'ın "Tuple" özelliği harika bir alternatiftir.
*   **Tuple Nedir?** Farklı tipteki birden fazla nesneyi, arka planda yeni bir sınıf oluşturmadan geçici olarak tek bir paket (parantez içinde) haline getiren yapıdır.
*   **İsimlendirilmiş Tuple (Named Tuple) Avantajı:** 
    Eğer Tuple'ı sadece `(student, course)` şeklinde gönderirseniz, View tarafında bunlara `@Model.Item1` ve `@Model.Item2` şeklinde erişirsiniz ki bu okunaklı değildir. 
    Bunun yerine `(s: student, c: course)` şeklinde bir "İsimlendirilmiş Tuple" fırlatırsanız, HTML tarafında otomatik tamamlama desteğiyle `@Model.s.Name` veya `@Model.c.Title` şeklinde muazzam bir okunabilirlik elde edersiniz. Gecici ve hızlı veri aktarımlarında mükemmel bir silahtır.
