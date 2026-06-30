using System.ComponentModel.DataAnnotations;

namespace Backend
{
    public class EmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Position_id { get; set; }
    }
}
