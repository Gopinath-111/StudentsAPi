using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.Model
{
    public class StudentsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current date and time
        public string? DeletedBy { get; set;  }
        public DateTime DeletedAt { get; set; }

    }
}
