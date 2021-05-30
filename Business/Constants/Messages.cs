﻿namespace Business.Constants
{
    //Bu sınıf geri dönüş mesajlarını şablon olarak kullanmak için kullanılır.
    //Northwind projesine özel oldugu için Business katmanına yazdık.
    public static class Messages //Mesajları newlememek gerekir.
    {
        //Peki bu basit değişkenlerin isim başını neden büyük harfle yazdık ?
        //Nedeni public olması. pascal case
        public static string ProductAdded = "Ürün Eklendi";

        public static string ProductNameInvalid = "Ürün ismi geçersiz";

        public static string MaintanceTime = "Sistem Bakımda";

        public static string ProductListed = "Ürünler Listelendi";

        public static string ProductCountOfCategoryError = "Bu kategorinin ürün sınırı dolmuş";

        public static string ProductNameAlreadyExists = "Bu isimde zaten baska bir ürün var";

        public static string CategoryLimitExceed = "Maksimum kategori sayisini astiniz, yeni ürün ekleyemezsiniz";
    }
}