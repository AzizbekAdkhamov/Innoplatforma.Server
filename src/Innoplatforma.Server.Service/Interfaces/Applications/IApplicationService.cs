using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Applications;

namespace Innoplatforma.Server.Service.Interfaces.Applications;

public interface IApplicationService
{
    Task<bool> RemoveAsync(long id);
    Task<ApplicationForResultDto> RetrieveByIdAsync(long id);
    Task<ApplicationForResultDto> CreateAsync(ApplicationForCreationDto dto);
    Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto);
    Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params);

}
