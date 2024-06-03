using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiFiltersTask.Contexts;
using WebApiFiltersTask.Contracts;
using WebApiFiltersTask.Models;

namespace WebApiFiltersTask.Services;

public class UserLoginService:IUserLoginService
{
    private readonly IConfiguration _configuration;
    private readonly UserRoleContext _context;
    private readonly TokenService _tokenStorage;

    public UserLoginService(IConfiguration configuration, UserRoleContext context, TokenService tokenStorage)
    {
        _configuration = configuration;
        _context = context;
        _tokenStorage = tokenStorage;
    }

    public async Task<string> Login(UserLogin user)
    {
        var userRecord = await _context.Handlers.FirstOrDefaultAsync(u => u.Email == user.Email);
        if (userRecord == null || userRecord.Password != user.Password)
        {
            return string.Empty;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWTToken:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Email", user.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string userToken = tokenHandler.WriteToken(token);

        return userToken;
    }

    public UserLogin GetUserByUserName(string userName)
    {
        return _context.Handlers.SingleOrDefault(u => u.Email == userName);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
