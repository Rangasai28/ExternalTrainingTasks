using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApiFiltersTask.Contracts;
using WebApiFiltersTask.Filter;


namespace WebApiFiltersTask.Controllers;


[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(RoleBasedAccessFilter))]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IMemoryCache cache;
    string CacheKey = "Users";

    public UserController(IUserService userService,IMemoryCache cache)
    {
        this.userService = userService;
        this.cache = cache;
    }

  

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Login(Models.User user)
    {
        var token = await userService.Login(user);
        return Ok(token);
    }



   
    [HttpGet]
  

    public async Task<IEnumerable<Models.User>> GetUsers()
    {
        var users = await userService.GetUsers();
        return users;
    }


   
    [HttpGet("getusers")]
    public async Task<IEnumerable<Models.User>> GetAllUsers()
    {
        var users = await userService.GetUsers();
        return users;
    }

  
    [HttpGet("delete")]
    public IActionResult DeleteEmployee()
    {
        return Ok("Accessed by Manager");
    }

   
    [HttpGet("adduser")]
    public IActionResult AddUser()
    {
        return Ok("This is accessed by only HR");
    }

    [HttpGet("addproduct")]
    public IActionResult AddProduct()
    {
        return Ok("This is accessed by only HR");
    }

    [HttpGet("updateproduct")]
    public IActionResult UpdateProduct()
    {
        return Ok("This is Accessed by only Employee");
    }

    [HttpGet("updatedetails")]
    public IActionResult UpdateDetails()
    {
        return Ok("This is Accessed by only Employee");
    }
}
