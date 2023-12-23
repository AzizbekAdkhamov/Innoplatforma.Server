using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Auth;

public class Role : Auditable<short>
{
    public string Name { get; set; }
}
