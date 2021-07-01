using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //İsin icerisinde sifreleme olan sistemlerde her seyin byte array formatında vermemiz gerek
    //appsettins jsondaki securitykey
    //Basit bir stringle key olmaz --mysupersecret keyi asp.net jwt'nin anlayacagi sekle sokuyoruz
    //SeuciryKey'i stringle encryptiona parametre geçemeyiz, onu byte array haline getirip encryptiona geçirmeliyiz

    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //Encoding.UTF8.GetBytes(bir string)  <--- Bu metod string ifadelerin her harfini ascii koduna cevirip bir diziye aktarir bu byte[] dizisidir.
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//stringi simetrik anahtara cevirdik
        }
    }
}
