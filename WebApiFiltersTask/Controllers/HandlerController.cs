using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiFiltersTask.Contracts;
using WebApiFiltersTask.Filter;
using WebApiFiltersTask.Models;
using WebApiFiltersTask.Services;

namespace WebApiFiltersTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HandlerController : ControllerBase
{
    private readonly IUserLoginService _userService;
    private readonly TokenService _tokenStorage;

    public HandlerController(IUserLoginService userService, TokenService tokenStorage)
    {
        _userService = userService;
        _tokenStorage = tokenStorage;
    }
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserLogin user)
    {
        var token = await _userService.Login(user);
        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("Invalid login attempt.");
        }

        return Ok(token);
    }
    [Authorize]
    [HttpGet("demo")]
    [ServiceFilter(typeof(LoginBasedAccessFilter))]
    public ActionResult DemoMethod()
    {
        return Ok("Demo method success");
    }

    [Authorize]
    [HttpPost("logout")]
    public ActionResult Logout()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ").LastOrDefault();
        var userTokenDTO = _tokenStorage._tokens.FirstOrDefault(x => x.Token == token);
        if (userTokenDTO != null)
        {
            _tokenStorage.RemoveToken(userTokenDTO.Token);
            return Ok("Logged out successfully");
        }
        else
        {
            return BadRequest("Invalid token. Logout failed.");
        }
    }
}
