using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //İsin icerisinde sifreleme olan sistemlerde her seyin byte array formatında vermemiz gerek
    //appsettins jsondaki securitykey
    //Basit bir stringle key olmaz --mysupersecret keyi asp.net jwt'nin anlayacagi sekle sokuyoruz
    //bunları asp.net jwt servislerinin anlayacagi sekile sokuyoruz
    //SeuciryKey'i stringle encryptiona parametre geçemeyiz, onu byte array haline getirir
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//stringi simetrik anahtara cevirdik
        }
    }
}
