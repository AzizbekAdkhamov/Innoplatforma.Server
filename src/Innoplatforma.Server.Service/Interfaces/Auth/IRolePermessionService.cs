using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;
using Innoplatforma.Server.Service.DTOs.Auth.RolePermissions;

namespace Innoplatforma.Server.Service.Interfaces.Auth;

public interface IRolePermessionService
{
    Task<bool> RemoveAsync(long id);
    Task<RolePermessionForResultDto> RetrieveByIdAsync(long id);
    Task<RolePermessionForResultDto> CreateAsync(RolePermissionForCreationDto dto);
    Task<RolePermessionForResultDto> ModifyAsync(long id, RolePermissionForUpdateDto dto);
    Task<IEnumerable<RolePermessionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
