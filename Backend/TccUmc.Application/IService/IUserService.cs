using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;

namespace TccUmc.Application.IService;

public interface IUserService
{
    Task<CreateUserResponseDto> PreRegisterAccount(CreateUserDto userDto);
    Task ValidateUserEmailAccount(string token);
    Task RequestAccountPasswordChange(RequestUpdateUserPasswordDto userDto);
    Task ChangeAccountPassword(UpdateUserPasswordDto userDto);
    Task<CreateUserResponseDto> ContinueAccountRegister(UpdateUserDto userDto, string? email);
    Task ResendValidateUserEmailAccountToken(string email);
    Task<GetUserEmailAndDocument> GetUserEmailAndDocument(string? value);
}