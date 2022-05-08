using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackendUmc.Application.DTO.Request;
using TccBackendUmc.Application.DTO.Response;
using TccBackendUmc.Application.Interfaces;

namespace TccBackendUmc.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Login using email and password
    /// </summary>
    /// <param name="model">Email and password</param>
    /// <returns>JWT, Expire date, Permission</returns>
    [AllowAnonymous]
    [HttpPost]
    public LoginResponseDto Login([FromBody] LoginRequestDto model)
    {
        return _authService.Login(model);
    }
}