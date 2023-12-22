using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Organizations;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class OrganizationDetailAsset : Auditable<long>
{
    public long OrganizationDetailId { get; set; }
    public OrganizationDetail OrganizationDetail { get; set; }
}
