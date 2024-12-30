using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Students.Data;
using Students.DTO;
using Students.Model;
using Students.Repository.IRepository;

namespace Students.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _config;
        public AdminRepository(AppDbContext dbContext, IConfiguration config)
        {
            this.dbContext = dbContext;
            _config = config;
        }
        public async Task<AdminModel> Authenticate(AdminDTO admin)
        {
            var user = await dbContext.Admin.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == admin.Email.ToLower().Trim());
            if(user != null)
            {
                bool IsPassValid = BCrypt.Net.BCrypt.Verify(admin.Password, user.Password);
                if(IsPassValid)
                {
                    return user;
                }
            }
            return null;
        }

        public string GenerateToken(AdminModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims :    claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
