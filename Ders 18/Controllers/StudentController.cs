using Microsoft.AspNetCore.Mvc;
using App.Models;

namespace App.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // 1. VERİ TEMİNİ: Veritabanından iki farklı ve bağımsız nesne çekildiğini varsayalım.
            var ogrenci = new Student { Id = 1, FullName = "Enes Bilgin" };
            var kurs = new Course { CourseId = 101, Title = "ASP.NET Core 5.0 Mimari Eğitimi", Credit = 5 };

            // 2. TUPLE OLUŞTURMA VE VIEW'A GÖNDERME
            // View sadece tek bir "Model" kabul eder. Bu iki nesneyi ayrı ayrı yollayamayız.
            // ViewModel (Yeni bir class) oluşturmak yerine 'Named Tuple (İsimlendirilmiş Demet)' ile 
            // bu iki nesneyi tek bir pakete (paranteze) sıkıştırıyoruz.
            // s = Öğrenci nesnesi (student)
            // c = Kurs nesnesi (course)
            
            var combinedData = (s: ogrenci, c: kurs);

            // Bu birleştirilmiş tekil paketi (Tuple) View'a fırlatıyoruz.
            return View(combinedData);
        }
    }
}
