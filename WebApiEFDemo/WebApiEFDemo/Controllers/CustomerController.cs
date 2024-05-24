using Microsoft.AspNetCore.Mvc;
using WebApiEFDemo.Data;
using WebApiEFDemo.Models;

namespace WebApiEFDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    ContextClass context;
    public CustomerController(ContextClass contextClass)
    {
        context = contextClass;
    }

    [HttpGet("/Customers")]
    public List<Customer> Get()
    {
        return context.Customer.ToList<Customer>();
    }

    [HttpPost("/AddCustomer")]
    public string Post([FromBody] Customer customer)
    {
        context.Customer.Add(customer);
        context.SaveChanges();
        return "Customer Record Created Successfully";
    }

    [HttpPut("/UpdateCustomer")]
    public string Put([FromBody] Customer customer)
    {
        context.Customer.Update(customer);
        context.SaveChanges();
        return "Customer Record Updated Successfully";
    }

    [HttpDelete("/DeleteCustomer")]

    public string Delete([FromBody] Customer customer)
    {
        context.Customer.Remove(customer);
        context.SaveChanges();
        return "Deleted Successfully";
    }
}
