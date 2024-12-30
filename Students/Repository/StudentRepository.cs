using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Model;
using Students.Repository.IRepository;

namespace Students.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;
        public StudentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(StudentsModel student)
        {
            await dbContext.AddAsync(student);
            await Save();
        }
        public async Task Update(StudentsModel student)
        {
            dbContext.Students.Update(student);
            await Save();
        }
        public async Task<List<StudentsModel>> GetAll()
        {
            var stds = await dbContext.Students
                                      .Where(x => x.IsDeleted != true)
                                      .ToListAsync();
            return stds;
        }
        public async Task<StudentsModel> GetById(int stdid)
        {
            StudentsModel Details = await dbContext.Students.FirstOrDefaultAsync(u => u.Id == stdid && !u.IsDeleted);
            return Details;
        }
        public async Task Save()
        {
           await dbContext.SaveChangesAsync();
        }
        public bool IsStudentExists(string name, string fatherName, string mobileNo)
        {
            string StdName = name.ToLower().Trim();
            string Fathername = fatherName.ToLower().Trim();
            string Mobileno = mobileNo.ToLower().Trim();

            var exists = dbContext.Students.AsQueryable()
                .Any(x => x.Name.ToLower().Trim() == StdName &&
                          x.FatherName.ToLower().Trim() == Fathername &&
                          x.MobileNo.ToLower().Trim() == Mobileno);
            return exists;
        }

        public bool IsEligibleForAge(DateOnly dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;

            // Adjust if the birthday hasn't occurred this year
            if (DateTime.Today < dateOfBirth.ToDateTime(TimeOnly.MinValue).AddYears(age))
            {
                age--;
            }

            return age >= 3 && age <= 100;
        }

    }
}
