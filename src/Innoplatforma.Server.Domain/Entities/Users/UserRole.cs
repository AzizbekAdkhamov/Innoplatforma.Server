using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class UserRole : Auditable<long>
{
    public int UserId { get; set; }
    public User User { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
}
