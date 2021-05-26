using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrate;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DepencyResolvers.Autofac
{
    //Peki bu ne işe yarayacak ?
    //startupdaki singletonları yapmayı sağlar
    public class AutofacBussinesModule:Module//Autofac modülünü seçin, system reflection değil
    {
        //uygulama çalıştıgı zaman load çalısacak
        //autofac singleton disinda interceptor sağlıyor
        protected override void Load(ContainerBuilder builder)
        {
            //bu addsingleton'a karsılık gelir
            //birisi senden IProductService isterse ProductManager'ver
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //SingleInstance, her şey için tek bir instance oluşturur.Dikkat: referans adresi her şey için aynıdır
            //data taşımamalı

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            //calisan uygulama içerisinde implemente edilen interfaceleri bul
            //onları için acspectinterceptor'u cagir
            //meali autofac bütün sınıflar için aspectini kontrol ediyor
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
