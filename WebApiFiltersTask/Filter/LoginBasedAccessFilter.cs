using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WebApiFiltersTask.DTOs;
using WebApiFiltersTask.Services;

namespace WebApiFiltersTask.Filter;

public class LoginBasedAccessFilter : IAuthorizationFilter
{
    private readonly TokenService _tokenStorage;

    public LoginBasedAccessFilter(TokenService tokenStorage)
    {
        _tokenStorage = tokenStorage;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var claims = context.HttpContext.User.Claims.ToDictionary(c => c.Type, c => c.Value);
        var userEmail = claims[claims.Keys.First()];

        var bearer = context.HttpContext.Request.Headers["Authorization"].ToString();
        var token = bearer.Split(" ").LastOrDefault();

        var ipAdress = context.HttpContext.Connection.RemoteIpAddress.ToString();

        if (ipAdress == "::1")
        {
            var adressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            ipAdress = adressList[1].ToString();
        }


        var userExists = _tokenStorage._tokens.FirstOrDefault(o => o.Email == userEmail);
        if (userExists == null)
        {
            var obj = new TokenDto()
            {
                Token = token,
                Email = userEmail,
                IpAdress = ipAdress,
            };

            _tokenStorage.AddToken(obj);
        }
        else
        {
            if (userExists.Token != token || userExists.Email != userEmail || userExists.IpAdress != ipAdress)
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "You already have an active session. Please close the previous tab."

                };
            }

        }
    }
}
