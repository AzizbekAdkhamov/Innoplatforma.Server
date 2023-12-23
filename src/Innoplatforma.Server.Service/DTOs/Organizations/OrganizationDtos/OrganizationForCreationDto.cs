
namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;

public class OrganizationForCreationDto
{
    public string Name { get; set; }
    public short SectionId { get; set; }
    public string Description { get; set; }
    public long LocationId { get; set; }
    public long OrganizationDetailId { get; set; }
}
