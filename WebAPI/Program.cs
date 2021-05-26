using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DepencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        //Burdaki mevzu biz varolan .net core altypas�ndanki �oc yap�s�n� kullanmak yerime
        //yeni �oc altyap�s� kullan
        //.net core container yerine ba�ka bir �oc container kullanmak i�in yazd�k
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBussinesModule()); //yeni addsingleton AutofacBussinesModule'de 
                }) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
