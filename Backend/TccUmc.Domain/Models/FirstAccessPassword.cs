namespace TccUmc.Domain.Models;

public class FirstAccessToken
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public bool WasUsed { get; set; }
}