using Microsoft.AspNetCore.Mvc;
using WebApiEFDemo.Data;
using WebApiEFDemo.Models;

namespace WebApiEFDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    ContextClass context;
    public EmployeeController(ContextClass contextClass)
    {
        context = contextClass;
    }

    [HttpGet("/Employees")]
    public List<Employee> Get()
    {
        return context.Employee.ToList<Employee>();
    }

    [HttpPost("/AddEmployees")]
    public string Post([FromBody] Employee employee)
    {
        context.Employee.Add(employee);
        context.SaveChanges();
        return "Employee Record Created Successfully";
    }

    [HttpPut("/UpdateEmployee")]
    public string Put([FromBody] Employee employee)
    {
        context.Employee.Update(employee);
        context.SaveChanges();
        return "Employee Record Updated Successfully";
    }

    [HttpDelete("/deleteemployee")]
    public string Delete([FromBody] Employee employee)
    {
        context.Employee.Remove(employee);
        context.SaveChanges();
        return "Deleted Successfully";
    }
}
