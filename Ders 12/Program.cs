using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App
{
    // ASP.NET Core uygulaması bir Konsol (Console) uygulaması olarak doğar.
    // İşletim sistemi projeyi başlattığında ilk olarak Program sınıfındaki Main metodu tetiklenir.
    public class Program
    {
        // 1. UYGULAMANIN GİRİŞ NOKTASI (ENTRY POINT)
        public static void Main(string[] args)
        {
            // Web sunucusunu yapılandıran metodu çağırır, Build (inşa) eder ve Run (çalıştır) diyerek sunucuyu yayına alır.
            CreateHostBuilder(args).Build().Run();
        }

        // 2. SUNUCU YAPILANDIRMASI (HOST BUILDER)
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Arka planda Kestrel (dahili web sunucusu) ayağa kaldırılır.
                    // Sisteme diyoruz ki: "Senin nasıl çalışacağını belirleyen asıl kurallar (Kalbin) Startup sınıfının içindedir."
                    webBuilder.UseStartup<Startup>();
                });
    }
}
