using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
