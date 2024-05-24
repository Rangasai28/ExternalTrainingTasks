namespace WebApiRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();

            app.MapGet("/", () => "api/employee");
            app.UseRouting();
            app.MapControllers();
            //  app.MapControllers();
            app.Run();
        }
    }
}
