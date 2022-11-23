using AutoMapper;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Application.IService;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.Service;

public class UserService : IUserService
{
    private readonly IMailSender _mailSender;
    private readonly IMapper _mapper;
    private readonly IResetPassword _resetPassword;
    private readonly IUserRepository _userRepository;
    private readonly IValidateAccountToken _validateAccountToken;

    public UserService(
        IMapper mapper,
        IUserRepository userRepository,
        IMailSender mailSender,
        IResetPassword resetPassword,
        IValidateAccountToken validateAccountToken
    )
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _mailSender = mailSender;
        _resetPassword = resetPassword;
        _validateAccountToken = validateAccountToken;
    }

    public async Task<CreateUserResponseDto> PreRegisterAccount(CreateUserDto userDto)
    {
        if (!Validate.IsEmailValid(userDto.Email)) throw new BadRequestException("Email invalido");

        var user = _mapper.Map<User>(userDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user = await _userRepository.CreateUser(user);
        var token = await _validateAccountToken.CreateValidateToken(user);
        await _mailSender.SentMailResetValidateAccount(user.Email, token.Token);
        return new CreateUserResponseDto
        {
            Guid = user.Guid,
            Email = user.Email
        };
    }

    public async Task ValidateUserEmailAccount(string token)
    {
        var tokenValidate = await _validateAccountToken.GetValidateToken(token);
        if (tokenValidate == default || tokenValidate.ExpirationDate < DateTime.Now)
            throw new BadRequestException("Token inválido");

        await _userRepository.ValidateUserEmailAccount(tokenValidate.User);
        await _validateAccountToken.RevokeValidateToken(tokenValidate.Token);
    }

    public async Task RequestAccountPasswordChange(RequestUpdateUserPasswordDto userDto)
    {
        var user = await _userRepository.GetUserByEmail(userDto.Email);
        if (user == null) throw new BadRequestException("Email não cadastrado");
        var resetPasswordToken = await _resetPassword.CreateResetPasswordToken(user);
        await _mailSender.SentMailResetPassword(user.Email, resetPasswordToken.Token);
    }

    public async Task ChangeAccountPassword(UpdateUserPasswordDto userDto)
    {
        var user = await _userRepository.GetUserByEmail(userDto.Email);
        if (user == default) throw new BadRequestException("Email não cadastrado");

        var resetToken = await _resetPassword.GetResetPasswordToken(user, userDto.Token);
        if (resetToken == default || resetToken.ExpirationDate < DateTime.Now)
            throw new BadRequestException("Token inválido");

        await _userRepository.ChangePasswordUser(userDto.NewPassword, user);
        await _resetPassword.RevokeResetPasswordToken(user, userDto.Token);
    }

    public async Task<CreateUserResponseDto> ContinueAccountRegister(UpdateUserDto userDto, string? email)
    {
        var user = _mapper.Map<User>(userDto);
        user.Email = email ?? string.Empty;
        user = await _userRepository.UpdateUser(user);
        return _mapper.Map<CreateUserResponseDto>(user);
    }

    public async Task ResendValidateUserEmailAccountToken(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == default) throw new BadRequestException("Usuário não cadastrado");

        var token = await _validateAccountToken.RecreateValidateToken(user);
        await _mailSender.SentMailResetValidateAccount(token.User.Email, token.Token);
    }

    public async Task<GetUserEmailAndDocument> GetUserEmailAndDocument(string? value)
    {
        var user = await _userRepository.GetUserByEmail(value);
        if (user == default) throw new BadRequestException("Usuário não encontrado");

        return new GetUserEmailAndDocument
        {
            Guid = user.Guid,
            Email = user.Email,
            Cpf = user.Cpf
        };
    }
}