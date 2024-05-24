using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRoutingDemo.Data;
using WebApiRoutingDemo.Models;

namespace WebApiRoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly ContextClass employeeContext;
        public EmployeeController(ContextClass context)
        {
            employeeContext = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetStudents()
        {
            return await employeeContext.Customer.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetStudent(int id)
        {
            if (employeeContext.Customer == null)
            {
                return NotFound(); // 404 - preferred to return results in HTTP codes
            }
            var employee = await employeeContext.Customer.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<Employee>> SearchEmployeeByName(string name)
        {
            if (employeeContext.Customer == null)
            {
                return NotFound(); // 404 - preferred to return results in HTTP codes
            }
            var employee = await employeeContext.Customer.FirstOrDefaultAsync(e => e.Name == name);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Employee>> AddStudent(Employee employee)
        {
            employeeContext.Customer.Add(employee);
            await employeeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = employee.Id }, employee);
        }
    }
}
