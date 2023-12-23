using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Service.DTOs.Sections;

public class SectionForResultDto
{
    public short Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Organization> Organizations { get; set; }
}