using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Client'e verdigimiz token
    //AccessToken, Yetki gereken isteklerde(operasyon vs) jwt tokenini de koyup göndermek.
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
