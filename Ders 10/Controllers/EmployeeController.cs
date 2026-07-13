using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Collections.Generic;

namespace App.Controllers
{
    // ==========================================
    // CONTROLLER KATMANI (İstek Karşılama ve Orkestrasyon)
    // ==========================================
    // Sistemdeki trafiği yöneten orkestra şefidir.
    // İstemciden (tarayıcı) gelen HTTP isteklerini yakalar.
    public class EmployeeController : Controller
    {
        // İstemci 'site.com/Employee/Index' URL'ine GET isteği attığında bu Action çalışır.
        public IActionResult Index()
        {
            // 1. VERİ TEMİNİ (Model ile İletişim):
            // Normalde bu veri veritabanından çekilir. Senaryo gereği bellekte sahte veri üretiyoruz.
            var employeeList = new List<Employee>
            {
                new Employee { Id = 1, FullName = "Ali Yılmaz", Department = "IT", Salary = 25000 },
                new Employee { Id = 2, FullName = "Ayşe Kaya", Department = "HR", Salary = 22000 },
                new Employee { Id = 3, FullName = "Veli Demir", Department = "Finance", Salary = 28000 }
            };

            // 2. VIEW'A (ARAYÜZE) AKTARIM:
            // Controller, veriyi elde etti. Şimdi bu saf veriyi (employeeList)
            // ekranda çizmesi (render) için ilgili View (Index.cshtml) dosyasına fırlatıyor.
            // Bu hareket "Separation of Concerns" (Sorumlulukların Ayrılığı) ilkesinin temelidir.
            return View(employeeList);
        }
    }
}
