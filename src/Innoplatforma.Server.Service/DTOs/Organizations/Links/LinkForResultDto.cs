namespace Innoplatforma.Server.Service.DTOs.Organizations.Links;

public class LinkForResultDto
{
    public long Id { get; set; }    
    public long OrganizationDetailId { get; set; }
    public string Name { get; set; }
    public string LinkUrl { get; set; }
}
