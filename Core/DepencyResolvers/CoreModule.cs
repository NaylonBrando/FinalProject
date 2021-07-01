using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DepencyResolvers
{
    //Core katmaninda bütün projeler için genel ihtiyac olan depencyresolver
    //Uyari: businessteki bağımlılıların çözüldügü AutofacBusinessModule sadece FinalProjecte özeldir
    //burası genel servis bagimlilklarini cözecegimiz yer
    //startupa yazacagimiza burada tutuyoruz
    //bu services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); a benzer
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
