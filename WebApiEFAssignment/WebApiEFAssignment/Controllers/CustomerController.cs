using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEFAssignment.Data;
using WebApiEFAssignment.Models;

namespace WebApiEFAssignment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    readonly ContextClass context;
    static List<CustomerProductTemp> list = new List<CustomerProductTemp>();

    public CustomerController(ContextClass contextClass)
    {
        context = contextClass;
    }

    [HttpGet("/Customers")]
    public IActionResult GetCustomers()
    {
        return Ok(context.Customer.ToList<Customer>());
    }



    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        context.Customer.Add(customer);
        context.SaveChanges();
        return Ok("Added Successfully");
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Customer customer)
    {
        context.Customer.Remove(customer);
        context.SaveChanges();
        return Ok("Deleted Successfully");
    }

   

    [HttpGet("/details")]
    public async Task<IActionResult> CustomerProductDetails(ContextClass context)
    {
        var customerProducts = await context.CustomerProduct.ToListAsync();
         
        List<CustomerProductTemp> list = new List<CustomerProductTemp>();

        foreach (var cp in customerProducts)
        {
            CustomerProductTemp cpt = new CustomerProductTemp();
            cpt.Products = new List<Product>();
            Customer customer = await context.Customer.FindAsync(cp.CustomerId);
            Product product = await context.Products.FindAsync(cp.ProductId);
            cpt.customerId = customer.Id;
            cpt.customerName = customer.Name;
            cpt.Products.Add(new Product { Id = cp.ProductId, Name = product.Name });
            list.Add(cpt);
        }
       
            return Ok(list);
    }

}
