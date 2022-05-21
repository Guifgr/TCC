using TccUmc.Domain.Models;

namespace TccUmc.Infrastructure.IRepository;

public interface IResetPassword
{
    Task<ResetPasswordToken> CreateResetPasswordToken(User user);
    Task<ResetPasswordToken> GetResetPasswordToken(User email, string token);
    Task RevokeResetPasswordToken(User user, string token);
}