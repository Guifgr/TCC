using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IResetPassword
{
    Task CreateResetPasswordToken(User email, string token);
    Task<ResetPasswordToken> GetResetPasswordToken(User email, string token);
    Task RevokeResetPasswordToken(User email, string token);
}