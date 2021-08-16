using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        //kendi yazdigimiz middleware
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) //this IApplicationBuilder, IApplicationBuilder'i extend ediyor
        {
            app.UseMiddleware<ExceptionMiddleware>();//bize middlewareyi genisletmek icin hazir usemiddleware metodu verilmis
        }
    }
}
