using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //Bu sınıf geri dönüş mesajlarını şablon olarak kullanmak için kullanılır.
    //Northwind projesine özel oldugu için Business katmanına yazdık.
    public static class Messages //Mesajları newlememek gerekir.
    {
        //Peki bu basit değişkenlerin isim başını neden büyük harfle yazdık ?
        //Nedeni public olması. pascal case
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string MaintanceTime="Sistem Bakımda";
        internal static string ProductListed="Ürünler Listelendi";
    }
}
