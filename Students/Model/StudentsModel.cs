using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.Model
{
    public class StudentsModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        [StringLength(50, ErrorMessage = "Father's Name cannot exceed 50 characters")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\+?[0-9]{10,10}$", ErrorMessage = "Invalid Mobile Number format")]
        public string MobileNo { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current date and time
        public string? DeletedBy { get; set;  }
        public DateTime DeletedAt { get; set; }

    }
}
