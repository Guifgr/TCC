using Microsoft.AspNetCore.Http;
using TccUmc.Domain.Exceptions;

namespace TccUmc.Utility.Extensions;

public static class ContextHttpExtensions
{
    public static string GetHttpContextId(this HttpContext context)
    {
        var id = context.User.Claims.FirstOrDefault(x => x.Type == "id")?.ToString();
        if (id == null)
        {
            throw new BadRequestException("Token não autorizado para a requisição");
        }
        return id["id: ".Length..];
    }
    public static string GetHttpContextCdClient(this HttpContext context)
    {
        var cdClient = context.User.Claims.FirstOrDefault(x => x.Type == "cd_client")?.ToString();
        if (cdClient == null)
        {
            throw new BadRequestException("Token não autorizado para a requisição");
        }
        return cdClient["cd_client: ".Length..];
    }
}
