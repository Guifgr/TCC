using Microsoft.EntityFrameworkCore;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class ResetPassword : IResetPassword
{
    private readonly TccContext _context;

    public ResetPassword(TccContext context)
    {
        _context = context;
    }

    public async Task<ResetPasswordToken> CreateResetPasswordToken(User user)
    {
        var resetToken = new ResetPasswordToken
        {
            User = user,
            Token = Guid.NewGuid().ToString(),
            ExpirationDate = DateTime.Now.AddHours(1)
        };
        await _context.ResetPasswordTokens.AddAsync(resetToken);
        await _context.SaveChangesAsync();
        return resetToken;
    }

    public async Task<ResetPasswordToken> GetResetPasswordToken(User email, string token)
    {
        return await _context.ResetPasswordTokens.FirstOrDefaultAsync(x => x.User == email && x.Token == token);
    }

    public async Task RevokeResetPasswordToken(User user, string token)
    {
        _context.ResetPasswordTokens.Remove(await GetResetPasswordToken(user, token));
        await _context.SaveChangesAsync();
    }
}