using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //Dto: Data Transmation Object
    //sqldeki inner join gibi tabloları kesistirip eşleşenleri çekmeye yarıyor
    //ilişkisel tablolari bir arada getirmeye yarıyor
    //dto adında bir nesne oluşturup istedigimiz sütun alanlarını o classa yazdıktan çekecegimiz yerde linq ile inner join
    //yapıp veriyi getiriyoruz

    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnıtsInStock { get; set; }

    }
}
