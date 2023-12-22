namespace Innoplatforma.Server.Service.Interfaces.Auth;

public interface IPermissionService
{
<<<<<<< Updated upstream
    
}
=======
    Task<bool> RemoveAsync(int id);
    Task<PermissionForResultDto> RetrieveByIdAsync(int id);
    Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto);
    Task<PermissionForResultDto> ModifyAsync(int id, PermissionForUpdateDto dto);

    Task<IEnumerable<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
>>>>>>> Stashed changes
