using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash//Salt ve hashi olusturur, sonra yollar
            (string password, out byte[] passwordHash, out byte[] passwordSalt)//gelen sifrenin hashini ve saltini olusturacak//outdısarıya döndürelecek
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//Haslemek için .net kriptografi sınıfından yararlaniyoruz
            {
                //Salt olarak algnin key degerini kullaniyoruz. her kullanici icin yeni key
                passwordSalt = hmac.Key;
                //İlk olarak password'u stringden bytearray yapmak icin bu dönüstürmeyi kullandık
                //bytre[] formunda stringin her harfi ascii tablosundaki sayi karsıligina cevrildi
                //İkinci olarak HMACSHA512 sınıfınından türetilen nesne için verilen key değerine göre hash olusturuldu
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //Kullanicinin gönderdiği passwordu ayni algoritma ve önceden olusturulmus salti ile hashle ve karsilastir
        public static bool VerifyPasswordHash
            (string password, byte[] passwordHash, byte[] passwordSalt)

        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHast = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHast.Length; i++)
                {
                    if (computedHast[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
