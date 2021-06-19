using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    
    public class SigningCredentialsHelper
    {
        //1:35:00 vs ---1:43:00
        //Bu sınıf wep apinin kullanabilecegi jwt tokenlerinin olusturabilmesi icin
        //Hashing işlemi yapacaksın, anahtar olarak bu securitykeyi kullan
        //jwt key doğrulama, hangi anahtar ve hangi algoritma
        //cridential, user cridental sisteme girmek icin kullanilan e posta ve sifre vs
        public static SigningCredentials CreateSigningCredantials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
