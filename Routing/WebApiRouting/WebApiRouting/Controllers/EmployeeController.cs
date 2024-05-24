using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiRouting.Models;
namespace WebApiRouting.Controllers
{
   // [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> productsList = new List<Employee>()
         {
             new Employee { Id = 101, Name = "Bala", Department = "IT"},
             new Employee { Id = 102, Name = "Ranga", Department = "IT"}
         };


        [Route("Employee/all")]
        [HttpGet]
        public ActionResult<List<Employee>> GetProducts()
        {
            return productsList;
        }
    }
}
