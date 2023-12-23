using Innoplatforma.Server.Domain.Entities.Users;

namespace Innoplatforma.Server.Service.Interfaces.Commons;

public interface IAuthService
{
    public string GenerateToken(User users);
}