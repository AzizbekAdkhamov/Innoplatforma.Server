using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class Profession : Auditable<int>
{
    public string Name { get; set; }
}
