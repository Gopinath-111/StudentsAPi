using System.ComponentModel.DataAnnotations;

namespace Students.Model
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
         public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        //[StringLength(50, ErrorMessage = "Role cannot exceed 50 characters")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        //[StringLength(50, ErrorMessage = "Role ID cannot exceed 50 characters")]
        public int RoleId { get; set; }
    }
}
