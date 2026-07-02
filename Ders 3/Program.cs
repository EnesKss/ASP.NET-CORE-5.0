using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App
{
    // ASP.NET Core uygulamaları temelde birer konsol uygulaması olduğu için
    // uygulama çalıştırıldığında işletim sistemi ilk olarak bu sınıftaki Main metodunu tetikler.
    public class Program
    {
        // 1. Main Metodu: Uygulamanın Giriş Noktası (Entry Point)
        public static void Main(string[] args)
        {
            // Web sunucusunu (Kestrel) hazırlayan metodu çağırır, 
            // yapılandırır (Build) ve projeyi yayına alır (Run).
            CreateHostBuilder(args).Build().Run();
        }

        // 2. CreateHostBuilder Metodu: Uygulamanın Barındırma (Hosting) Altyapısının Kurulması
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Uygulamanın "Kalbi" olan Startup dosyasını buraya bağlıyoruz.
                    // Kestrel sunucusu bu Startup dosyasındaki kurallara göre çalışacaktır.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
