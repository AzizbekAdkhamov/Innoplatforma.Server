using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;

namespace Innoplatforma.Server.Service.Interfaces.Users;

public interface IUserProfessionService
{
    Task<bool> RemoveAsync(long id);
    Task<UserProfessionForResultDto> RetrieveByIdAsync(long id);
    Task<UserProfessionForResultDto> CreateAsync(UserProfessionForCreationDto dto);
    Task<UserProfessionForResultDto> ModifyAsync(long id, UserProfessionForUpdateDto dto);
    Task<IEnumerable<UserProfessionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
