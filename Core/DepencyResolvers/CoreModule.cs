using Core.CrossCuttingConcers.Caching;
using Core.CrossCuttingConcers.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DepencyResolvers
{
    //Core katmaninda bütün projeler için genel ihtiyac olan depencyresolver
    //Uyari: businessteki bağımlılıların çözüldügü AutofacBusinessModule sadece FinalProjecte özeldir
    //burası genel servis bagimlilklarini cözecegimiz yer
    //startupa yazacagimiza burada tutuyoruz
    //ek olarak buradaki depency injection aspect icindir
    //bu services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); a benzer
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Alltaki cözücü ileride baska memorycache manager kullanirsak hemen cözümleyelim diye
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddMemoryCache();//Core.CrossCuttingConcers.Caching.Microsoft'teki IMemorCache için çözücü. hazir bir cözücü
            serviceCollection.AddSingleton<Stopwatch>();

        }
    }
}
