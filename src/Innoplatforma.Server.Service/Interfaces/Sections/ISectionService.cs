using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Sections;
namespace Innoplatforma.Server.Service.Interfaces.Sections;

public interface ISectionService
{
    Task<bool> RemoveAsync(short id);
    Task<SectionForResultDto> RetrieveByIdAsync(short id);
    Task<SectionForResultDto> CreateAsync(SectionForCreationDto dto);
    Task<SectionForResultDto> ModifyAsync(short id, SectionForUpdateDto dto);
    Task<IEnumerable<SectionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}