using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.Links;

namespace Innoplatforma.Server.Service.Interfaces.Organizations.Links;

public interface ILinkService
{
    Task<bool> RemoveAsync(long id);
    Task<LinkForResultDto> RetrieveByIdAsync(long id);
    Task<LinkForResultDto> CreateAsync(LinkForCreationDto dto);
    Task<LinkForResultDto> ModifyAsync(long id, LinkForUpdateDto dto);
    Task<IEnumerable<LinkForResultDto>> RetrieveAllAsync(PaginationParams @params);
}