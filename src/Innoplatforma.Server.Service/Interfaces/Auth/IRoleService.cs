using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;

namespace Innoplatforma.Server.Service.Interfaces.Auth;

public interface IRoleService
{
    Task<bool> RemoveAsync(short id);
    Task<RoleForResultDto> RetrieveByIdAsync(short id);
    Task<RoleForResultDto> CreateAsync(RoleForCreationDto dto);
    Task<RoleForResultDto> ModifyAsync(short id, RoleForUpdateDto dto);
    Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
