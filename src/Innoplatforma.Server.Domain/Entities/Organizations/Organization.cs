using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.References;
using Innoplatforma.Server.Domain.Entities.Sections;

namespace Innoplatforma.Server.Domain.Entities.Organizations;

public class Organization: Auditable<long>
{
    public string Name { get; set; }
    public short SectorId { get; set; }
    public Section Section { get; set; }
    public string Description { get; set; }

    public long LocationId { get; set; }
    public Location Location { get; set; }

    public long OrganizationCardId { get; set; }
    public OrganizationDetail OrganizationDetail { get; set; }
}