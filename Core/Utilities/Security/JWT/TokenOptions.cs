using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //jwt tokenin çeşitli standatları vardır bizim bunlari veiroyr olmamiz gerekir
    //tokenin audience, issure, securitykey gibi standart olarak sahip olması gereken şeyler vardır
    //bu bilgileri bir nesne vasıtasiyla veririz
    //Tokenoptions bilgilerini appsettingsin içinde tutacagiz ama nesne olarak map edip o nesne 
    //üzerinden kullanmak daha iyidir
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
