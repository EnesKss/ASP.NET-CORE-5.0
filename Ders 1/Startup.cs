public class Startup
{
    // 1. Dependency Injection (DI) Konteynerine Servislerin Eklenmesi
    public void ConfigureServices(IServiceCollection services)
    {
        // MVC mimarisi için Controller ve View servislerini uygulamaya dahil eder.
        services.AddControllersWithViews();
        
        // Örnek: Kendi servislerinizi burada DI'a eklersiniz (İleride IStudentService gibi)
        // services.AddScoped<IStudentService, StudentService>();
    }

    // 2. HTTP Request Pipeline (İstek Hattı) Yapılandırması
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Geliştirme ortamı için detaylı hata sayfası
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Canlı ortam için hata yönlendirmesi ve güvenlik politikaları
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();  // HTTP isteklerini HTTPS'e yönlendirir
        app.UseStaticFiles();       // wwwroot içindeki statik dosyaların kullanımını açar

        app.UseRouting();           // İstek yönlendirme mekanizmasını başlatır

        app.UseAuthorization();     // Yetkilendirme (Varsa) adımı

        // MVC route (rota) şemasının belirlenmesi
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
