using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProductCustomerAsync.Data;
using WebApiProductCustomerAsync.Models;

namespace WebApiProductCustomerAsync.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    readonly ContextClass context;
    public ProductController(ContextClass dbcontext)
    {
        context = dbcontext;
    }


    [HttpGet("/getproducts")]

    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await context.Products.ToListAsync();
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<Product>> GetProductById(int Id)
    {
        if (context.Products == null)
        {
            return NotFound();
        }
        var product = await context.Products.FindAsync(Id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);

    }

    [HttpPost("/addproduct")]
    public  async Task<ActionResult<Product>> AddProduct(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    //[HttpPut("{Id}")]
    //public async Task<ActionResult> UpdateProduct(Product product,int Id)
    //{
    //    if (Id != product.Id)
    //    {
    //        return BadRequest();
    //    }
    //    context.Entry(product).State = EntityState.Modified;

    //    try
    //    {
    //        await context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!ProductExists(Id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    //[HttpDelete("{Id}")]
    //public async Task<ActionResult> DeleteProduct(int Id)
    //{
    //    if (context.Products == null)
    //    {
    //        return NotFound();
    //    }

    //    var product = await context.Products.FindAsync(Id);
    //    if (product == null)
    //    {
    //        return NotFound();
    //    }

    //    context.Products.Remove(product);
    //    await context.SaveChangesAsync();


    //    return NoContent();
    //}

    [HttpGet("/Customerproduct")]
    public async Task<ActionResult<IEnumerable<CustomerProduct>>> GetDetails()
    {
        return await context.CustomerProducts.ToListAsync();
    }

    //[HttpPost("/Customerproductid")]

    //public async Task<ActionResult<CustomerProduct>> AddCustomerProductId( CustomerProduct customerProduct)
    //{
    //    context.CustomerProducts.Add(customerProduct);
    //    await context.SaveChangesAsync();
    //    return Ok(customerProduct);
    //}

    //[HttpDelete("/delete")]
    //public IActionResult deletecpt(CustomerProduct customerProduct)
    //{
    //    context.CustomerProducts.Remove(customerProduct);
    //    context.SaveChanges();
    //    return Ok();
    //}
    private bool ProductExists(int id)
    {
        return (context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
