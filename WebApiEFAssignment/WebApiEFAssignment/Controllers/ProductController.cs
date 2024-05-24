using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEFAssignment.Data;
using WebApiEFAssignment.Models;


namespace WebApiEFAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly ContextClass context;

        public ProductController(ContextClass contextClass)
        {
            context = contextClass;
        }


        [HttpGet("/Products")]
        public IActionResult GetProducts()
        {
            return Ok(context.Products.ToList<Product>());
        }

        [HttpPost("/Addproduct")]
        public IActionResult Post([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("/DeleteProduct")]
        public IActionResult DeleteProduct([FromBody] Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("/Customerproduct")]
        public IActionResult Get()
        {
            return Ok(context.CustomerProduct.ToList<CustomerProduct>());
        }

        [HttpPost("/Customerproductid")]

        public IActionResult AddCustomerProductPId([FromBody] CustomerProduct customerProduct)
        {
            context.CustomerProduct.Add(customerProduct);
            context.SaveChanges();
            return Ok(customerProduct);
        }

        [HttpDelete("/delete")]
        public IActionResult deletecpt([FromBody] CustomerProduct customerProduct)
        {
            context.CustomerProduct.Remove(customerProduct);
            context.SaveChanges();
            return Ok();
        }
    }
}
