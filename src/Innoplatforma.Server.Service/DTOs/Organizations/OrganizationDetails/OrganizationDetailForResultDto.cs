using Innoplatforma.Server.Service.DTOs.Organizations.Links;

namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;

public class OrganizationDetailForResultDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ShortPhone { get; set; }
    public string Description { get; set; }
    public string OrganizationLink { get; set; }
    public string FilePath { get; set; }
    public IEnumerable<LinkForResultDto> Links { get; set; }
}
