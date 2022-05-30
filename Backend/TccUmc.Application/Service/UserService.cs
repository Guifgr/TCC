using AutoMapper;
using TccUmc.Application.DTO.Users.Request;
using TccUmc.Application.DTO.Users.Response;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;
using TccUmc.Application.IService;
using TccUmc.Domain.Exceptions;
using TccUmc.Utility.Helpers;

namespace TccUmc.Application.Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IResetPassword _resetPassword;
    private readonly IMailSender _mailSender;

    public UserService(
        IMapper mapper,
        IUserRepository userRepository,
        IMailSender mailSender, 
        IResetPassword resetPassword)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _mailSender = mailSender;
        _resetPassword = resetPassword;
    }

    public async Task<CreateUserResponseDto> CreateUser(CreateUserDto userDto)
    {
        if (!Validate.IsEmailValid(userDto.Email))
        {
            throw new BadRequestException("Email invalido");
        }
        
        if (!Validate.IsCpf(userDto.Cpf))
        {
            throw new BadRequestException("Cpf invalido");
        }

        if (userDto.Cnpj != string.Empty && !Validate.IsCnpj(userDto.Cnpj))
        {
            throw new BadRequestException("Cnpj invalido");
        }
        
        var user = _mapper.Map<User>(userDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user = await _userRepository.CreateUser(user);
        return new CreateUserResponseDto
        {
            UserGuid = user.Guid,
            Email = user.Email
        };
    }

    public async Task RequestChangePasswordUser(RequestUpdateUserPasswordDto userDto)
    {
        var user = await _userRepository.GetUserByEmail(userDto.Email);
        if (user == null)
        {
            throw new NotFoundException("Email não cadastrado");
        }
        var resetPasswordToken = await _resetPassword.CreateResetPasswordToken(user);
        await _mailSender.SentMailResetPassword(user.Email, resetPasswordToken.Token);
    }

    public async Task ChangePasswordUser(UpdateUserPasswordDto userDto)
    {
        var user = await _userRepository.GetUserByEmail(userDto.Email);
        if (user == default)
        {
            throw new NotFoundException("Email não cadastrado");
        }
        
        var resetToken = await _resetPassword.GetResetPasswordToken(user, userDto.Token);
        if (resetToken == default || resetToken.ExpirationDate < DateTime.Now)
        {
            throw new NotFoundException("Token inválido");
        }
        
        await _userRepository.ChangePasswordUser(userDto.NewPassword, user);
        await _resetPassword.RevokeResetPasswordToken(user, userDto.Token);
    }
}