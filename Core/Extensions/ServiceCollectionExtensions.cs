using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //Bu yaptigimiz metod(hareket) core katmani da dahil olmak üzere ekleyecegimiz bütün injectionlari bir arada toplayabilecegimiz yapi
    //bütün projeler icin ortak servisler icin
    //extensionlarda classlar static olur
    public static class ServiceCollectionExtensions
    {
        //apinin servis bagimliliklari ekledigimiz koleksiyon
        //this neyi genisletmek istiyorsaniz oraya yazdiginiz sey
        //poliformizm
        //buraya parametre olarak core module + vs falan ekleyecegiz
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules) //birden fazla modülü ekleye bilecegimizi gösterir
            {
                module.Load(serviceCollection);
            }
            //bu startuptaki servicetool.createnin coklu servis injectionu
            return ServiceTool.Create(serviceCollection);
        }
        
    }
}
