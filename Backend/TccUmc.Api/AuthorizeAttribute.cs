using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TccUmc.Domain.Enums;

namespace TccUmc.Api;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<Role> _roles;

    public AuthorizeAttribute(params Role[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var claims = context.HttpContext.User.Identities.First().Claims.ToList();
        var roleClaim = claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value ?? string.Empty;

        var userRoles = roleClaim.Split(',').ToList();
        var allowedRoles = string.Join(',', _roles).Split(',').ToList();

        var isUserRoleAllowed = userRoles.Any(role => allowedRoles.Exists(x => x == role));
        
        if (_roles.Any() && !isUserRoleAllowed)
        {
            context.Result = new JsonResult(new {message = "Unauthorized"})
                {StatusCode = StatusCodes.Status401Unauthorized};
        }
    }
}