using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class AdminDetailsDTO
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
