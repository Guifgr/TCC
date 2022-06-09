using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IUserRepository
{
    Task<User> GetUserByCredentials(string cpf);
    void VerifyUserPassword(string password, User user);
    Task<User> CreateUser(User user);
    Task<User> GetUserById(int id);
    Task<User> GetUserByEmail(string userDtoEmail);
    Task ChangePasswordUser(string newPassword, User user);
    Task<User> UpdateUser(User user);
    Task ValidateUserEmailAccount(User tokenValidateUser);
}