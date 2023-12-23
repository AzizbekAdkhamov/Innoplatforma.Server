using Innoplatforma.Server.Service.DTOs.Organizations.Links;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;

namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;

public class OrganizationForResultDto
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ShortPhone { get; set; }
    public string Description { get; set; }
    public string OrganizationLink { get; set; }
    public OrganizationDetailAssetForResultDto Asset { get; set; }
    public IEnumerable<LinkForResultDto> Links { get; set; }
}
