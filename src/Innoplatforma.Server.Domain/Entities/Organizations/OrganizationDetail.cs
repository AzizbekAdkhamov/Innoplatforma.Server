using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Assets;

namespace Innoplatforma.Server.Domain.Entities.Organizations;

public class OrganizationDetail : Auditable<long>
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ShortPhone { get; set; }
    public string Description { get; set; }
    public string OrganizationLink { get; set; }

    public IEnumerable<Link> Links { get; set; }
    public OrganizationDetailAsset Asset { get; set; }
}