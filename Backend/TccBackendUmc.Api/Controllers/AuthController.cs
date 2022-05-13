using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackendUmc.Application.DTO.Login.Request;
using TccBackendUmc.Application.DTO.Login.Response;
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
    /// User Login using email and password
    /// </summary>
    /// <param name="model">Email and password</param>
    /// <returns>JWT, Expire date, Permission</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<LoginResponseDto> UserLogin([FromBody] UserLoginRequestDto model)
    {
        return await _authService.UserLogin(model);
    }
    
    /// <summary>
    /// Clinic Login using email and password
    /// </summary>
    /// <param name="model">Email and password</param>
    /// <returns>JWT, Expire date, Permission</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<LoginResponseDto> ClinicLogin([FromBody] ClincLoginRequestDto model)
    {
        return await _authService.ClinicLogin(model);
    }
}