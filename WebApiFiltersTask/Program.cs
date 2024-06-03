using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiFiltersTask.Contexts;
using WebApiFiltersTask.Contracts;
using WebApiFiltersTask.Filter;
using WebApiFiltersTask.Services;

namespace WebApiFiltersTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<UserRoleContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("cs")));
        builder.Services.AddScoped<RoleBasedAccessFilter>();
        builder.Services.AddScoped<LoginBasedAccessFilter>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserLoginService, UserLoginService>();
        builder.Services.AddSingleton<TokenService>();
        builder.Services.AddMemoryCache();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
     .AddJwtBearer(o =>
     {
         o.RequireHttpsMetadata = true;
         o.SaveToken = true;
         o.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTToken:Key"])),
             ValidateIssuer = false,
             ValidateAudience = false
         };
     });
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
