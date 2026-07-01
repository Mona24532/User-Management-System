using System.ComponentModel.DataAnnotations;

namespace Backend
{
    public class EmployeeLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
     
    }
}
