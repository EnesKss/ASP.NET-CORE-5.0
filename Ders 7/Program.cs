using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // ASP.NET Core uygulamasının web sunucusu (Hosting) ve 
        // Ters Vekil (Reverse Proxy) yapılandırmasının kurulduğu temel iskelet.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // ==========================================
                    // 1. VARSAYILAN SUNUCU: KESTREL
                    // ==========================================
                    // ConfigureWebHostDefaults metodu, siz açıkça yazmasanız bile 
                    // arka planda '.UseKestrel()' metodunu otomatik çağırarak 
                    // uygulamanın inanılmaz hızlı, cross-platform Kestrel sunucusunda çalışmasını sağlar.

                    // ==========================================
                    // 2. TERS VEKİL ENTEGRASYONU: IIS
                    // ==========================================
                    // Canlı ortamda (Production) veya 'launchSettings.json'da IISExpress profili 
                    // seçildiğinde, uygulama IIS'in arkasında durur. 
                    // 'UseIISIntegration()' metodu, ön taraftaki IIS ile arka taraftaki 
                    // Kestrel arasındaki haberleşme köprüsünü (port, header aktarımları vb.) kurar.
                    webBuilder.UseIISIntegration();

                    // 3. Uygulamanın kalbini (Startup) sisteme bağlama
                    webBuilder.UseStartup<Startup>();
                });
    }
}
