namespace TccUmc.Domain.Models;

public class ResetPasswordToken
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
}