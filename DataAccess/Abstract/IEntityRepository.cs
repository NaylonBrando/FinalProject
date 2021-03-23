﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //1:
    //Her entity için .....Dal yazıp, o dal için ayrı ayrı kod yazmaktansa
    //generic vasitasiyla IEntityRepository şablonu kullanabiliriz
    //Yani sablon içinde sablon inherit ediyoruz kullaniyoruz.

    //2:
    //Generic Constraint(Generic Kısıt)
    //IEntityRepository'nin T'sini sınırlamak.
    //T'yi sadece entities'in veritabani nesnelerine sinirlayacagiz
    //class: referans tip
    //T artik sadece IEntity etiketli referans tipleri alabilir. 
    //Herhangi bir referans tipi ve int, string gibi değer tiplerini alamaz!
    //new() eklememizin nedeni newlenebilir olmalıdır. Parametre olarak direkt IEntity almaması için. İnterface newlenemez
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); //Data'yi filreleyip getimek için kullaniyoruz. 
        //Bununla kategoriye göre getir, ürüne göre getir vs için ayri ayri kodlar yazmak yerine tek şablonla çözeceksin
        //"Expression<Func<T, bool>> filter=null" <-- Bunu linqdaki gibi verileri getirme olarak düşünebilirsin
        //Veya sqldeki where şartları gibi
        //Filter yazmak zorunlu. filter=null filtre vermeye bilirsin demek. Filtre yoksa tüm datayi istiyor.
        
        //Get, tek bir data getirmek için, bir sistemde detaya gitmek için kullanilir. 
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        
        //List<T> GetAllByCategory(int categoryId); GetAll metodu ile artık buna ihtiyac kalmadi.
    }
}