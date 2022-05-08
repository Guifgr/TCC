using System.Web;
using MailKit.Security;
using MimeKit;
using TccBackendUmc.Domain.Models;
using TccBackendUmc.Infrastructure.IRepository;

namespace TccBackendUmc.Infrastructure.Repository;

public class MailSender : IMailSender
{
    public async Task<bool> SentMailFirstAccess(string email, string token)
    {
        var emailText = $"http://localhost:3000/definirSenha?token={HttpUtility.HtmlEncode(token)}\n";
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Programação Gás", Environment.GetEnvironmentVariable("MailSender")));

        message.To.Add(Environment.GetEnvironmentVariable("PdgEnv") == "Production"
            ? MailboxAddress.Parse(email)
            : MailboxAddress.Parse(Environment.GetEnvironmentVariable("MailReceiver")));

        message.Subject = "Primeiro acesso Programação Gás";
        message.Body = new TextPart("plain")
        {
            Text = "Clique abaixo para redefinir senha\n" + emailText
        };

        return await MailSmtp(emailText, message);
    }
    private static async Task<bool> MailSmtp(string emailText, MimeMessage message)
    {
        var client = new MailKit.Net.Smtp.SmtpClient();

        var host = Environment.GetEnvironmentVariable("ServerSmtp");
        var port = int.Parse(Environment.GetEnvironmentVariable("ServerPortSmtp") ?? string.Empty);
        var sender = Environment.GetEnvironmentVariable("MailSender");
        var senderPassword = Environment.GetEnvironmentVariable("EmailPassword");

        try
        {
            await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(sender, senderPassword);
            await client.SendAsync(message);
            Console.WriteLine(emailText);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }

        return true;
    }
}   