using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class StudentDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
