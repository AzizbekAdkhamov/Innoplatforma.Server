using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Auth;

public class Premession : Auditable<int>
{
    public string Name { get; set; }
}
