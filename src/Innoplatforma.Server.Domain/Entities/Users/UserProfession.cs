using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class UserProfession : Auditable<long>
{
    public long UserId { get; set; }
    public User User { get; set; }

    public int ProfessionId { get; set; }
    public Profession Profession { get; set; }
}
