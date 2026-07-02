using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        // 1. ConfigureServices Metodu: IoC Container & Servis Kayıt Noktası
        // Bu metot, uygulama çalışmadan (runtime'dan hemen önce) tetiklenir.
        // Veritabanı context'leri, dış servisler, modüller buradaki bağımlılık havuzuna (DI Container) eklenir.
        public void ConfigureServices(IServiceCollection services)
        {
            // Sisteme MVC mimarisini (Controller ve View) kazandıran standart servis.
            services.AddControllersWithViews();

            // Örnek: Kendi yazdığımız bir servisin (Dependency Injection ile) sisteme tanıtılması
            // services.AddScoped<IMyService, MyService>();
        }

        // 2. Configure Metodu: HTTP Request Pipeline (İstek Hattı) & Middleware
        // Gelen her bir HTTP isteğinin hangi filtrelerden / ara yazılımlardan (Middleware) geçeceğini sırasıyla belirler.
        // Burada çalışma sırası çok önemlidir (Chain of Responsibility - Sorumluluk Zinciri).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ortam Geliştirme (Development) ortamıysa detaylı hata sayfasını göster.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Gelen istekleri HTTP'den güvenli olan HTTPS'e otomatik yönlendir.
            app.UseHttpsRedirection();

            // İstemcinin "wwwroot" klasöründeki statik dosyalara (CSS, JS, resimler) erişebilmesine izin ver.
            app.UseStaticFiles();

            // İsteklerin hangi koda / Controller'a gideceğinin mekanizmasını (Routing) başlat.
            app.UseRouting();

            // Eğer sistemde giriş yapma mantığı olsaydı, yönlendirmeden hemen sonra yetki kontrolü (Authorization) yapılırdı.
            app.UseAuthorization();

            // İstek hattının son noktası: İsteklerin Controller ve Action'lara nasıl eşleşeceği belirleniyor.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
