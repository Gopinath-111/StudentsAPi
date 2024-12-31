using System.ComponentModel.DataAnnotations;

namespace Students.Model
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        //[StringLength(50, ErrorMessage = "Role cannot exceed 50 characters")]
        public string Role { get; set; }

        [Required]
        //[StringLength(50, ErrorMessage = "Role ID cannot exceed 50 characters")]
        public int RoleId { get; set; }
    }
}
