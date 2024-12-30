using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class AdminDetailsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }
    }
}
