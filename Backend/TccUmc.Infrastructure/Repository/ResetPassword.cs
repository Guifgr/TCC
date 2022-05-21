using TccUmc.Domain.Models;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class ResetPassword : IResetPassword
{
    public Task CreateResetPasswordToken(User email, string token)
    {
        throw new NotImplementedException();
    }

    public Task<ResetPasswordToken> GetResetPasswordToken(User email, string token)
    {
        throw new NotImplementedException();
    }

    public Task RevokeResetPasswordToken(User email, string token)
    {
        throw new NotImplementedException();
    }
}