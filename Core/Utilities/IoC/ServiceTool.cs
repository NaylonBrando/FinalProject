using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //bu sınıf bizim wep api veya autofacteki injectionlari olustuturmaya yarar
    //istediginiz herhangi bir interfacenin servisini bu tool ile alabilirsiiz
    //Ioc
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //.netin servislerini al VE onlari kendin built et
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
