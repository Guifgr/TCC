using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccBackendUmc.Application.DTO.Request;
using TccBackendUmc.Application.DTO.Request.Users;
using TccBackendUmc.Application.DTO.Response;
using TccBackendUmc.Application.DTO.Response.User;
using TccBackendUmc.Application.Interfaces;

namespace TccBackendUmc.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Create A New User
    /// </summary>
    /// <param name="UserDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<CreateUserResponseDto> CreateAccount([FromBody] CreateUserDto UserDto)
    {
        return await _userService.CreateUser(UserDto);
    }
}