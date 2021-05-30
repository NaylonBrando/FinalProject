using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //IoC Container:
            //Normalde console app kullanýrken altypýyý kullanmak için ilgili manageri ve daldan nesne olusturmamýz gerekir
            // Bu da bunu saðlýyor
            //Bana arka planda bir referans oluþtur.
            //Birisi senden constructorda IProductService isterse ona arka planda new ProductManager oluþtur ve ver.
            //Bu metodu cagiracak olan her servise ayni referans adresini verir. Tüm bellekte bir adet productmanager olustutur. bütün clientlere ayný instanceyi verir.
            //içerisinde data tutmuyorsanýz kullanýn, tek alýþveriþ sepetinin herkesin kullanmasý gibi.
            //services.AddSingleton<IProductService, ProductManager>(); //Iproduct service için üretilen ProductManager instancesi
            //services.AddSingleton<IProductDal, EfProductDal>(); //IProductDal için üretilen EfProductDal instancesi
            //AOP
            //Autofac, ninject, castlewindsor, structure map, lightinject, dryinject ---> IoC container
            // .net'in containerini býrakýp, Autofac containere geçtik
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}