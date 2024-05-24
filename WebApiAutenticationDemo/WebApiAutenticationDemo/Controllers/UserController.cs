using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiAutenticationDemo.Contracts;
using WebApiAutenticationDemo.Models;

namespace WebApiAutenticationDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private  IUserService userService;
    
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }


    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Login(User user)
    {
      var token = await userService.Login(user);
      return Ok(token);
    }


    [Authorize]
    [HttpGet]

    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await userService.GetUsers();
        return Ok(users);
    }

}
