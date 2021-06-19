using Core.Entities;

namespace Entities.DTOs
{
    //Sisteme kayıt işleminde kullanılacak authentication 
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; } //Kullanıcıdan string alıp kendimiz hashliyoruz
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}