using System.ComponentModel.DataAnnotations;

namespace Frontend
{
    public class LoginModel
    {

        [Required(ErrorMessage ="Email megadása kötelező")]
        [EmailAddress(ErrorMessage ="Email formátuma hibás")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Jelszó megadása kötelező")]
        public string Password { get; set; }      
       // public string Role { get; set; }
        

    }
}
