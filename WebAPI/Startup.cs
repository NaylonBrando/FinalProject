using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Normalde console app kullan�rken altyp�y� kullanmak i�in ilgili manageri ve daldan nesne olusturmam�z gerekir
            // Bu da bunu sa�l�yor
            //Bana arka planda bir referans olu�tur.
            //Birisi senden constructorda IProductService isterse ona arka planda new ProductManager olu�tur ve ver.
            //Bu metodu cagiracak olan her servise ayni referans adresini verir. T�m bellekte bir adet productmanager olustutur. b�t�n clientlere ayn� instanceyi verir.
            //i�erisinde data tutmuyorsan�z kullan�n, tek al��veri� sepetinin herkesin kullanmas� gibi.
            //services.AddSingleton<IProductService, ProductManager>(); //Iproduct service i�in �retilen ProductManager instancesi
            //services.AddSingleton<IProductDal, EfProductDal>(); //IProductDal i�in �retilen EfProductDal instancesi
            //AOP
            //Autofac, ninject, castlewindsor, structure map, lightinject, dryinject ---> IoC container
            





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