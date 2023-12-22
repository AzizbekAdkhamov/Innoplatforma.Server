using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Domain.Entities.Sections;

public class Section : Auditable<short>
{
    public string Title { get; set; }
    public IEnumerable<Organization> Organizations { get; set; }
}
