using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrate
{
    //Peki user, operationclaims, useroperationclams neden Core katmanında?
    //Çünkü Jwt sınıfları parametre olarak User sınıfını falan kullanıyor.
    //User vs Entities katmanında durursa bu sefer Core katmani Entities katmanına bagimli olur
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
