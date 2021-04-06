using Core.Entities;

namespace Entities.Concrate
{
    /*ciplak class kalmasin! Eger class inheritence veya implement almiyorsa
    /ilerde problem yaşayabiliriz. Bunu çözmek için varliklarımizi isaretleme (gruplama)
    /egilimine gideriz.
    /Entities'in concrate siniflari, veritabanimizin tablolarina karşılık geliyor.
    /dolayisiyla IEntiti bizim için veritabani nesnesi demektir
    */

    public class Category : IEntity //Artik bu interfaceden anliyoruz ki bu vt nesnesidir.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}