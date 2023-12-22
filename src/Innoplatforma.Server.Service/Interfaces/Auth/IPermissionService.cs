using Innoplatforma.Server.Service.DTOs.Auth.Permissions;

namespace Innoplatforma.Server.Service.Interfaces.Auth;

public interface IPermissionService 
{
    Task<bool> RemoveAsync(int id);
    Task<PermissionForResultDto> RetrieveByIdAsync(int id);
    Task<PermissionForResultDto> CreateAsync(PermissionForResultDto dto);
    Task<PermissionForResultDto> ModifyAsync(int id, PermissionForUpdateDto dto);

    //Task<IEnumerable<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}