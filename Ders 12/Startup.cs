using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        // IConfiguration nesnesi; appsettings.json dosyasını okuyabilmemiz için sisteme varsayılan olarak (DI ile) enjekte edilir.
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 1. SERVİS KAYIT MERKEZİ (IoC Container / Dependency Injection)
        // Uygulama ayağa kalkarken (Daha HTTP istekleri gelmeden önce) bir kez çalışır.
        // Veritabanı (DbContext), kütüphaneler ve dış servisler sisteme burada dahil edilir (Register).
        public void ConfigureServices(IServiceCollection services)
        {
            // Sisteme MVC (Controller-View) yeteneğinin eklenmesi
            services.AddControllersWithViews();

            // Örnek bir veritabanı servisinin eklenmesi
            // services.AddDbContext<MyContext>(options => ...);
        }

        // 2. İSTEK HATTI (HTTP Request Pipeline / Middleware)
        // İstemciden (Browser) gelen her bir HTTP isteğinin sunucuda sırasıyla hangi güvenlik 
        // ve işlem adımlarından geçeceğini belirleyen "Sorumluluk Zinciri"dir (Chain of Responsibility).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Geliştirme (Development) ortamında isek detaylı hatayı göster.
                app.UseDeveloperExceptionPage();
            }

            // wwwroot klasöründeki statik dosyaların (CSS, JS) dışarıya açılması
            app.UseStaticFiles();

            // İsteğin nereye (hangi Controller'a) gideceğinin belirlenmesi (Routing)
            app.UseRouting();

            // İstek hattının (Pipeline) sonu: İsteğin ilgili Action'a eşleştirilmesi
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
