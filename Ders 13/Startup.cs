using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        // ==========================================
        // 1. SERVİS KAYIT MERKEZİ
        // ==========================================
        public void ConfigureServices(IServiceCollection services)
        {
            // Uygulamanın bir "MVC Pipeline" işletebilmesi için 
            // Controller ve View motorlarını (Razor) sisteme dahil eden zorunlu servistir.
            services.AddControllersWithViews();
        }

        // ==========================================
        // 2. MVC REQUEST PIPELINE (İstek Yaşam Döngüsü Hattı)
        // ==========================================
        // Gelen her HTTP isteği (Request) bu metottaki sıraya göre çalışır.
        // Yazım sırası (üstten alta) mimari açıdan çok kritiktir (Chain of Responsibility).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // A) STATİK DOSYA ARA YAZILIMI (Middleware)
            // Eğer istek /images/logo.png gibi bir statik dosyaysa, uygulama 
            // MVC (Routing, Controller vb.) sürecini hiç başlatmaz, dosyayı 'wwwroot'tan 
            // anında istemciye fırlatır. Bu inanılmaz bir performans tasarrufudur.
            app.UseStaticFiles();

            // B) YÖNLENDİRME (ROUTING) ARA YAZILIMI
            // İsteğin adresini (URL) okur. "Bu URL sistemdeki hangi kod parçasına gitmek istiyor?" 
            // sorusunun cevabını araştırır ve hedefi (Endpoint) bellekte belirler.
            app.UseRouting();

            // C) ENDPOINT (VARIŞ NOKTASI) ARA YAZILIMI
            // İstek hattının son durağıdır. Routing'in belirlediği hedefle, Controller/Action'ı birbirine bağlar.
            app.UseEndpoints(endpoints =>
            {
                // STANDART MVC ROTA ŞABLONU (URL PARSING)
                // Şablon   : {controller}/{action}/{parametre}
                // Örnek URL: site.com/Product/Detail/5
                
                // --- NASIL ÇÖZÜMLENİR? ---
                // controller = Product -> ProductController sınıfını hafızada ayağa kaldırır.
                // action     = Detail  -> ProductController içindeki Detail(int id) metodunu tetikler.
                // id         = 5       -> Detail metoduna parametre olarak '5' değerini gönderir.
                // Eğer URL sadece "site.com" ise (değer yoksa), '=' işaretinden sonraki varsayılan 
                // değerler (Home ve Index) çalışır.
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
