using Innoplatforma.Server.Service.Services.Accounts.Models;

namespace Innoplatforma.Server.Service.Interfaces.Users;

public interface ISmsService
{
    public Task<bool> SendAsync(Message message);
    public Task<string> GenerateTokenAsync();
    public Task<bool> SendMessageByTelegramAsync(long groupId, string url, string text);
}
