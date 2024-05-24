using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string GetMessage()
        {
            return "Welcome to ASP.NET MVC Class,Displayed Using NON-Action Method";
        }

        public ContentResult ShowMessage()
        {
            return Content("Welcome to ASP.NET MVC Class ,Content is Displayed Using Action Method");
        }

        public ViewResult ShowData()
        {
            return View();
        }
    }
}
