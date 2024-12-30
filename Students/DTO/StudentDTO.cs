using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain alphabetic letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [StringLength(50, ErrorMessage = "Father's Name cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain alphabetic letters and spaces")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\+?[0-9]{10,10}$", ErrorMessage = "Invalid Mobile Number format")]
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
