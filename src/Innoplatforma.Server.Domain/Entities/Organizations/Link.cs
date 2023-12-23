using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Organizations;

public class Link : Auditable<long>
{
    public string Name { get; set; }
    public string LinkUrl { get; set; }

    public long OrganizationDetailId { get; set; }
    public OrganizationDetail OrganizationDetail { get; set; }

}
