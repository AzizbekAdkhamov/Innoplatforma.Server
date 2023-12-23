using Innoplatforma.Server.Service.Services.Accounts.Models;

namespace Innoplatforma.Server.Service.Interfaces.Accounts;

public interface IEmailService
{
    public Task SendMessageAsync(Message message);

    public Task<bool> SendCodeByEmailAsync(string email);

    public bool VerifyCode(string email, string code);
}
