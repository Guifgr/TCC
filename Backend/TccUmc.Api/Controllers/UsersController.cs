using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
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
    /// Pre Registration of a new user
    /// </summary>
    /// <param name="userDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<CreateUserResponseDto> PreRegisterAccount([Required][FromBody] CreateUserDto userDto)
    {
        return await _userService.PreRegisterAccount(userDto);
    }
    
    /// <summary>
    /// Pre Registration of a new user
    /// </summary>
    /// <param name="userDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ValidateUserEmailAccount([Required][FromQuery] string token)
    {
        await _userService.ValidateUserEmailAccount(token);
        return Ok("Conta validada com sucesso");
    }
    
    /// <summary>
        /// Pre Registration of a new user
        /// </summary>
        /// <param name="userDto">User Information for the signup</param>
        /// <returns>User Guid and user email</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResendValidateUserEmailAccountToken([Required][FromBody] string email)
        {
            await _userService.ResendValidateUserEmailAccountToken(email);
            return Ok("Token reenviado com sucesso!");
        }
    
    /// <summary>
    /// Update User Information
    /// </summary>
    /// <param name="userDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [HttpPut]
    public async Task<CreateUserResponseDto> ContinueAccountRegister([Required][FromBody] UpdateUserDto userDto)
    {
        return await _userService.ContinueAccountRegister(userDto, User.FindFirst(ClaimTypes.Email)?.Value);
    }
    
    /// <summary>
    /// Update User Information
    /// </summary>
    /// <param name="userDto">User Information for the signup</param>
    /// <returns>User Guid and user email</returns>
    [HttpGet]
    public async Task<GetUserEmailAndDocument> GetUserEmailAndDocument()
    {
        return await _userService.GetUserEmailAndDocument(User.FindFirst(ClaimTypes.Email)?.Value);
    }

    /// <summary>
    /// Request change password
    /// </summary>
    /// <param name="userDto">User Information</param>
    /// <returns>User email</returns>
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost]
    public async Task<IActionResult> RequestAccountPasswordChange([Required][FromBody] RequestUpdateUserPasswordDto userDto)
    {
        await _userService.RequestAccountPasswordChange(userDto);
        return Ok("Senha enviada para o email cadastrado");
    }
    
    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="userDto">User Information</param>
    /// <returns>User email</returns>
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [HttpPatch]
    public async Task<IActionResult> ChangeAccountPassword([Required][FromBody] UpdateUserPasswordDto userDto)
    {
        await _userService.ChangeAccountPassword(userDto);
        return Ok("Senha alterada com sucesso");
    }
}