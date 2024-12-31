using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class AdminDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }    
    }
}
