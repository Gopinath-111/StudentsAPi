using Students.DTO;
using Students.Model;

namespace Students.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<StudentsModel> GetById(int stid);
        Task Create(StudentsModel student);
        //Task Delete(StudentsModel student);
        Task Update(StudentsModel student);
        Task<List<StudentsModel>> GetAll();
        Task Save();
        bool IsStudentExists(string Name, string FatherName, string MobileNo);
        bool IsEligibleForAge(DateOnly dateOfBirth);
    }
}
