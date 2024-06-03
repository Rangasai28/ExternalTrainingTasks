using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiFiltersTask.Contexts;
using WebApiFiltersTask.Contracts;

namespace WebApiFiltersTask.Services;

public class UserService : IUserService
{
    private IConfiguration configuration;
    private UserRoleContext contextClass;

    public UserService(IConfiguration configuration, UserRoleContext contextDb)
    {
        this.configuration = configuration;
        contextClass = contextDb;
    }
    public async Task<IEnumerable<Models.User>> GetUsers()
    {
        return await contextClass.Users.ToListAsync();
    }

    public async Task<string> Login(Models.User newUser)
    {
        var matchedUser = await contextClass.Users.Where(u => u.Name == newUser.Name).FirstOrDefaultAsync();
        var userId = contextClass.Users.SingleOrDefault(u => u.Name == newUser.Name).Id;
        var userRoleId = contextClass.UserRoles.SingleOrDefault(u => u.UserId == userId).RoleId;
        var userRole = contextClass.Roles.SingleOrDefault(u => u.Id == userRoleId).RoleName;

        //  string role = await contextClass.UserRoles.Join()
        if (matchedUser == null)
        {
            return "Invalid Creadentials.";
        }
        if (matchedUser.Password != newUser.Password)
        {
            return "Passoword is Incorrect";
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["JWTToken:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, newUser.Name),
                    new Claim(ClaimTypes.Role, userRole)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string userToken = tokenHandler.WriteToken(token);
        return userToken;
    }

   public  async Task<(bool,IEnumerable<Models.User>)> GetAllUsers()
    {
        return (true, await contextClass.Users.ToListAsync());
    }
}
