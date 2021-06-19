using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrate
{
    //Peki user, operationclaims, useroperationclams neden Core katmanında?
    //Çünkü JWT Core katmanında. Jwt sınıfları parametre olarak user sınıfı falan kullanıyor.
    //referans aldıgı için bu sefer core katmanı entities katmanına referans olur

    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }//veritabanınde binary dediğimiz için byte array seçtik
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
