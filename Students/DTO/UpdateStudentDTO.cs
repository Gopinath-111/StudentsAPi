using System.ComponentModel.DataAnnotations;

namespace Students.DTO
{
    public class UpdateStudentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string FatherName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }

    }
}
