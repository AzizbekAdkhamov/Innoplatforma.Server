using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Auth;

public class RolePermession : Auditable<int>
{
    public short RoleId { get; set; }
    public Role Role { get; set; }
    public int PremessionId { get; set; }
    public Premession Premession { get; set; }
}
