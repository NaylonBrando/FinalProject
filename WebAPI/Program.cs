using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DepencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Burdaki mevzu biz varolan .net core altypasýndanki ýoc yapýsýný kullanmak yerine
        //yeni ýoc altyapýsý kullanmayi belirtiyoruz
        //.net core container(add singleton mevzusu) yerine baþka bir ýoc container kullanmak için yazdýk
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//servis saglayici fabrikasi olarak kullan
                .ConfigureContainer<ContainerBuilder>(builder => //autofac icin yazdigimizi buraya kodluyoruz
                {
                    builder.RegisterModule(new AutofacBussinesModule()); //yeni addsingleton AutofacBussinesModule'de
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}