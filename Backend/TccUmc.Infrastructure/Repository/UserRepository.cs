using Microsoft.EntityFrameworkCore;
using TccUmc.Domain.Exceptions;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly TccContext _tccContext;

    public UserRepository(TccContext tccContext)
    {
        _tccContext = tccContext;
    }

    public async Task<User> GetUserByCredentials(string email)
    {
        var result = await _tccContext.Users.FirstOrDefaultAsync(u =>
            u.Email.ToLower() == email.ToLower()
        );
        if (result == null) throw new BadRequestException("Usuário não encontrado");

        return result;
    }

    public void VerifyUserPassword(string password, User user)
    {
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new BadRequestException("Usuário ou senha incorretos");
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _tccContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == default) throw new BadRequestException("Usuário não encontrado");

        return user;
    }

    public Task<User> GetUserByEmail(string userDtoEmail)
    {
        return _tccContext.Users.FirstOrDefaultAsync(x => x.Email == userDtoEmail);
    }

    public async Task ChangePasswordUser(string newPassword, User user)
    {
        if (BCrypt.Net.BCrypt.Verify(newPassword, user.Password))
            throw new BadRequestException("Senha igual a anterior, utilize outra senha");

        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _tccContext.SaveChangesAsync();
    }

    public async Task<User> UpdateUser(User user)
    {
        var userEntity = await GetUserByEmail(user.Email);
        if (userEntity == null) throw new BadRequestException("Usuário não encontrado");

        userEntity.Cnpj = user.Cnpj;
        userEntity.Name = user.Name;
        userEntity.Address = user.Address;
        userEntity.Cpf = user.Cpf;

        _tccContext.Users.Update(userEntity);
        await _tccContext.SaveChangesAsync();
        return userEntity;
    }

    public async Task ValidateUserEmailAccount(User user)
    {
        user.IsActive = true;
        _tccContext.Users.Update(user);
        await _tccContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByGuid(Guid userGuid)
    {
        var user = await _tccContext.Users.FirstOrDefaultAsync(u => u.Guid == userGuid);
        if (user == default) throw new BadRequestException("Usuário não encontrado");
        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        if (await _tccContext.Users.AnyAsync(u => u.Email == user.Email || u.Cpf == user.Cpf))
            throw new BadRequestException("Usuário já cadastrado");
        await _tccContext.Users.AddAsync(user);
        await _tccContext.SaveChangesAsync();
        return user;
    }
}