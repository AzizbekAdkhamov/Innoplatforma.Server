using Innoplatforma.Server.Domain.Entities.Users;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class UserAsset : Asset
{
    public long UserId { get; set; }
    public User User { get; set; }
}
