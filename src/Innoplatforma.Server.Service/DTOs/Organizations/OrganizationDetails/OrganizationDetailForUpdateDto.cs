using Microsoft.AspNetCore.Http;

namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;

public class OrganizationDetailForUpdateDto
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string ShortPhone { get; set; }
    public string Description { get; set; }
    public string OrganizationLink { get; set; }
    public IFormFile Asset { get; set; }
}
