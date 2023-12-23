using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.References.Locations;

namespace Innoplatforma.Server.Service.Interfaces.References;

public interface IlocationService
{
    Task<bool> RemoveAsync(long id);
    Task<LocationForResultDto> RetrieveByIdAsync(long id);
    Task<LocationForResultDto> CreateAsync(LocationForCreation dto);
    Task<LocationForResultDto> ModifyAsync(long id, LocationForUpdateDto dto);
    Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
