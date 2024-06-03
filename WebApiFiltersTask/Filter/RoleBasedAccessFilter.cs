using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebApiFiltersTask.Contexts;

namespace WebApiFiltersTask.Filter;

public class RoleBasedAccessFilter : AuthorizeAttribute,IAuthorizationFilter
{
    private readonly UserRoleContext contextClass;
    public RoleBasedAccessFilter(UserRoleContext userRoleContext)
    {
        contextClass = userRoleContext; 
    }
   

    void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
    {
        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
        var controllerDescriptor = actionDescriptor?.ControllerTypeInfo.FullName;

        var methodInfo = actionDescriptor?.MethodInfo;
        var allowAnonymous = methodInfo?.IsDefined(typeof(AllowAnonymousAttribute), true) ?? false;

        if (allowAnonymous)
        {
            return;
        }

        var user = context.HttpContext.User;
        string? role = "";

        if (user.Identity is ClaimsIdentity identity)
        {
            var roleClaim = identity.FindFirst(ClaimTypes.Role);
             role = roleClaim?.Value;
        }
        var roleItem = contextClass.Roles.SingleOrDefault(r => r.RoleName == role);
        var actionRecords = contextClass.RoleBasedActions.Where(rb => rb.RoleId == roleItem.Id).Select(rb=>rb.ActionName).ToList();
        string routeActionName = context.ActionDescriptor.RouteValues["Action"];
        
        if (!actionRecords.Contains(routeActionName))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

    }
}
