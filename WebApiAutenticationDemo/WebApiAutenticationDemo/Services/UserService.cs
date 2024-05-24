using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiAutenticationDemo.Contracts;
using WebApiAutenticationDemo.Data;
using WebApiAutenticationDemo.Models;

namespace WebApiAutenticationDemo.Services;

public class UserService:IUserService
{
    private  IConfiguration configuration;
    private  ContextClass contextClass;

    public UserService(IConfiguration configuration,ContextClass contextDb) 
    {
        this.configuration = configuration;
        contextClass = contextDb;
    }

    public async Task<string> Login(User user)
    {
        User matchedUser = await contextClass.Users.Where(u => u.Name == user.Name).FirstOrDefaultAsync();
        if (matchedUser == null)
        {
            return "Invalid Creadentials.";
        }
        if(matchedUser.Password != user.Password)
        {
            return "Passoword is Incorrect";
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["JWTToken:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Name)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string userToken = tokenHandler.WriteToken(token);   
        return userToken;
    }
   
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await contextClass.Users.ToListAsync();
    }

   
}
