using Microsoft.EntityFrameworkCore;
using WebApiDTOsDemo.Config;
using WebApiDTOsDemo.Data;
using WebApiDTOsDemo.Repository;
using WebApiDTOsDemo.Services;
namespace WebApiDTOsDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {

            options.SuppressModelStateInvalidFilter = true;

        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ContextDb>(opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("cs")));
        var mapper = MapperConfig.IntializeMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddScoped<IStudentService, StudentService>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
