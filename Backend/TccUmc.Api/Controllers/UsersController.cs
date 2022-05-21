using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Application.IService;

namespace TccUmc.Api.Controllers;

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
    /// <param name="userDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<CreateUserResponseDto> CreateAccount([FromBody] CreateUserDto userDto)
    {
        return await _userService.CreateUser(userDto);
    }

    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="userDto">User Information</param>
    /// <returns>User email</returns>
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost]
    public async Task<IActionResult> ChangePasswordAccount([FromBody] UpdateUserPasswordDto userDto)
    {
        await _userService.ChangePasswordUser(userDto);
        return Ok("Senha enviada para o email cadastrado");
    }
}