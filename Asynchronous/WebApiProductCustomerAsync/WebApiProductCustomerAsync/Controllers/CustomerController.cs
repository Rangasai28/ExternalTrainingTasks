using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProductCustomerAsync.Data;
using WebApiProductCustomerAsync.Models;

namespace WebApiProductCustomerAsync.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    readonly ContextClass context;
    public CustomerController(ContextClass contextClass)
    {
        context = contextClass;
    }

    [HttpGet("/Customers")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await context.Customers.ToListAsync();
    }


    [HttpGet("{Id}")]

    public async Task<ActionResult<Product>> GetCustomerById(int Id)
    {
        if (context.Customers == null)
        {
            return NotFound();
        }
        var customer = await context.Customers.FindAsync(Id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);

    }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpGet("/details")]
    public async Task<IActionResult> CustomerProductDetails(ContextClass context)
    {
        var customerProductDetails = new List<CustomerProductDetails>();
        var customerProducts = await context.CustomerProducts.ToListAsync();
        var customers = await context.Customers.ToListAsync();
        var products = await context.Products.ToListAsync();
        foreach (var customer in customers)
        {
            var CustomerDetails = customerProducts.Where(cp => cp.CustomerId == customer.Id);

            var customerProductInfo = new CustomerProductDetails
            {
                customerId = customer.Id,
                customerName = customer.Name
            };
            foreach (var productDetails in CustomerDetails)
            {
                var product =  products.Find(p => p.Id == productDetails.ProductId); 

                if (product != null)
                {
                    customerProductInfo.products.Add(product);
                }
            }
            customerProductDetails.Add(customerProductInfo);
        }

        return Ok(customerProductDetails);
    }

}
