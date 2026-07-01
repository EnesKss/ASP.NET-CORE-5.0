using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    // ==========================================
    // KURGUSAL SERVİS ARAYÜZLERİ VE SINIFLARI
    // ==========================================
    
    // 1. Resim İşleme Servisi
    public interface IImageProcessingService 
    { 
        void ProcessImage(string path); 
    }
    public class ImageProcessingService : IImageProcessingService 
    { 
        public void ProcessImage(string path) { /* Resim işleme kodları */ } 
    }

    // 2. Loglama Servisi
    public interface ILoggingService 
    { 
        void LogError(string message); 
    }
    public class CustomLoggingService : ILoggingService 
    { 
        public void LogError(string message) { /* Loglama kodları */ } 
    }

    // ==========================================
    // STARTUP YAPILANDIRMASI
    // ==========================================

    public class Startup
    {
        // 1. MODÜLER ALTYAPI VE DEPENDENCY INJECTION (IoC) KAYIT ALANI
        // Sistemin kalbidir. İhtiyaç duyulan tüm modüller ve dış servisler buraya "takılır" (Plug & Play).
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC Modülünün (Controller ve View altyapısı) sisteme modüler olarak eklenmesi
            services.AddControllersWithViews();

            // Dışarıdan kurgusal servislerin sisteme "Dahili Dependency Injection" ile eklenmesi:
            
            // Scoped: Her HTTP isteğinde (Request) nesne 1 kez üretilir. O istek boyunca aynı nesne kullanılır.
            services.AddScoped<IImageProcessingService, ImageProcessingService>();

            // Singleton: Uygulama sunucuda ayağa kalktığında sadece 1 kez üretilir, tüm isteklere aynı nesne cevap verir.
            services.AddSingleton<ILoggingService, CustomLoggingService>();
            
            // Transient: (Alternatif) Nesneye her ihtiyaç duyulduğunda sıfırdan yepyeni bir örnek (instance) üretilir.
            // services.AddTransient<IOtherService, OtherService>();
        }

        // 2. HTTP İSTEK YAŞAM DÖNGÜSÜ (Middleware / Pipeline)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Statik dosyaların (Resim, CSS, JS) kullanımını sağlayan modülün (Middleware) devreye alınması
            app.UseStaticFiles(); 

            // Yönlendirme (Routing) mekanizmasının modüler olarak devreye alınması
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Standart MVC rotası
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
