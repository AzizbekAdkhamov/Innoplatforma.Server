using Innoplatforma.Server.Service.DTOs.Logins;

namespace Innoplatforma.Server.Service.Interfaces.Accounts;

public interface IAccountService
{
    public Task<string> LoginAsync(LoginDto loginDto);
}
