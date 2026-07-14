using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 1. MVC ALTYAPISININ SİSTEME EKLENMESİ
            // Boş bir projenin MVC özelliklerini (Controller okuma, View oluşturma) 
            // kazanabilmesi için gerekli kütüphanelerin Dependency Injection havuzuna eklenmesi.
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Uygulamanın statik dosyaları (wwwroot) kullanabilmesi için gerekli middleware
            app.UseStaticFiles();

            // 2. YÖNLENDİRME (ROUTING) MEKANİZMASININ AKTİF EDİLMESİ
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // 3. VARSAYILAN MVC ROTASININ (ENDPOINT) BELİRLENMESİ
                // İsteğin hangi Controller ve Action'a gideceğini belirten kalıptır.
                // "MapDefaultControllerRoute" komutu arka planda otomatik olarak şu rotayı yazar:
                // pattern: "{controller=Home}/{action=Index}/{id?}"
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
