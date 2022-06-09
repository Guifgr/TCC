using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IValidateAccountToken
{
    Task<UserValidationToken> CreateValidateToken(User user);
    Task<UserValidationToken> GetValidateToken(string token);
    Task RevokeValidateToken(string token);
    Task<UserValidationToken> RecreateValidateToken(User user);
}