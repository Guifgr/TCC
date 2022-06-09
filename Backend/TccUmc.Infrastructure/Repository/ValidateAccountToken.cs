using Microsoft.EntityFrameworkCore;
using TccUmc.Domain.Models;
using TccUmc.Infrastructure.Database.Context;
using TccUmc.Infrastructure.IRepository;

namespace TccUmc.Infrastructure.Repository;

public class ValidateAccountToken : IValidateAccountToken
{
    private readonly TccContext _context;

    public ValidateAccountToken(TccContext context)
    {
        _context = context;
    }


    public async Task<UserValidationToken> CreateValidateToken(User user)
    {
        var token = new UserValidationToken
        {
            User = user,
            Token = Guid.NewGuid().ToString(),
            ExpirationDate = DateTime.Now.AddHours(48)
        };

        await _context.UserValidationTokens.AddAsync(token);
        await _context.SaveChangesAsync();
        return token;
    }

    public async Task<UserValidationToken> GetValidateToken(string token)
    {
        return await _context.UserValidationTokens.Include(x => x.User).FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task RevokeValidateToken(string token)
    {
        _context.UserValidationTokens.Remove(await GetValidateToken(token));
        await _context.SaveChangesAsync();
    }

    public async Task<UserValidationToken> RecreateValidateToken(User user)
    {
        var tokens = await _context.UserValidationTokens.Include(x => x.User).Where(x => x.User == user).ToListAsync();
        foreach (var token in tokens)
        {
            await RevokeValidateToken(token.Token);
        }

        return await CreateValidateToken(user);
    }
}