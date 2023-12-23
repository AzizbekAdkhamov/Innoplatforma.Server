namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;

public class OrganizationForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public short SectionId { get; set; }
    public string Description { get; set; }
    public long LocationId { get; set; }
    public long OrganizationDetailId { get; set; }
}
