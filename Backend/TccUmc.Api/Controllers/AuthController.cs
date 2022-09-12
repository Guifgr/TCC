using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Request;
using TccUmc.Application.DTO.Response;
using TccUmc.Application.IService;

namespace TccUmc.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class AuthController : Controller
{
    private readonly IAuthService _userService;

    public AuthController(IAuthService userService)
    {
        _userService = userService;
    }

    /// <summary>
    ///     Login using email and password
    /// </summary>
    /// <param name="model">Email and password</param>
    /// <returns>JWT, Expire date, Permission</returns>
    [AllowAnonymous]
    [HttpPost]
    public Task<LoginResponseDto> Login([Required] [FromBody] LoginRequestDto model)
    {
        return _userService.LoginAsync(model);
    }
}