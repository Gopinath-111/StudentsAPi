using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Students.DTO;
using Students.Repository.IRepository;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository adminRepo;
        private readonly IMapper mapper;
        public AdminController(IAdminRepository adminRepository, IMapper mapping)
        {
            mapper = mapping;
            adminRepo = adminRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AdminDTO admin)
        {
            // Authenticate the admin user
            var user1 = await adminRepo.Authenticate(admin);
            var user = mapper.Map<AdminDetailsDTO>(user1);
            if (user == null)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "error",
                    message = "Invalid Email or Password",
                    accesstoken = (object)null,
                    data = (object)null
                });
            }

            if (user.RoleId == 1)
            {
                var token = adminRepo.GenerateToken(user1);
                return Ok(new
                {
                    statusCode = 200,
                    status = "success",
                    message = "Logged in Successfully",
                    accesstoken = token,
                    data = user
                });
            }

            return Ok(new
            {
                statusCode = 200,
                status = "error",
                message = "User is not an Admin",
                AccessToken = (object)null,
                data = (object)null
            });
        }
    }
}
