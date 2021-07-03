using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcers.Caching
{
    //Bu  bütün alternatif cachelerin interfacesidir
    public interface ICacheManager
    {
        void Add(string key, object value, int duration); //object bütün veri tiplerinin basesi //duration cache süresi
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);//cache de var mı kontrol, yoksa veri tabanından getirir sonra cache ekler
        void Remove(string key);//cacheden kaldırma
        void RemoveByPattern(string pattern); //1:22:30

    }                                                     

}
