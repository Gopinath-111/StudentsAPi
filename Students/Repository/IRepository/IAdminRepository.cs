using Students.DTO;
using Students.Model;

namespace Students.Repository.IRepository
{
    public interface IAdminRepository
    {
        Task<AdminModel> Authenticate(AdminDTO admin);

        string GenerateToken(AdminModel admin);
    }
}
