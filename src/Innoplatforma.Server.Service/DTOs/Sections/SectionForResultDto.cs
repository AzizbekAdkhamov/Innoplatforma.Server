using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Service.DTOs.Sections;

public class SectionForResultDto
{
    public string Title { get; set; }
    public IEnumerable<Organization> Organizations { get; set; }
}