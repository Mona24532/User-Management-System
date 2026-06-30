using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        
        public int PositionId { get; set; }

    }
}
