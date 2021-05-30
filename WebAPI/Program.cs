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

        //Burdaki mevzu biz varolan .net core altypas�ndanki �oc yap�s�n� kullanmak yerine
        //yeni �oc altyap�s� kullanmayi belirtiyoruz
        //.net core container(add singleton mevzusu) yerine ba�ka bir �oc container kullanmak i�in yazd�k
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