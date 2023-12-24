using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Professions;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;

namespace Innoplatforma.Server.Service.Interfaces.Professions;

public interface IProfessionService
{
    Task<bool> RemoveAsync(int id);
    Task<ProfessionForResultDto> RetrieveByIdAsync(int id);
    Task<ProfessionForResultDto> CreateAsync(ProfessionForCreatedDto dto);
    Task<ProfessionForResultDto> ModifyAsync(int id, ProfessionForUpdateDto dto);
    Task<IEnumerable<ProfessionForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
