namespace Students.DTO
{
    public class DeleteStudentDTO
    {
        public int Id { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; } = DateTime.UtcNow; 
    }
}
