using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;

namespace Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;

public interface IPersonalDataService
{
    Task<bool> RemoveAsync(long id);
    Task<PersonalDataForResultDto> RetrieveByIdAsync(long id);
    Task<PersonalDataForResultDto> CreateAsync(PersonalDataForCreationDto dto);
    Task<PersonalDataForResultDto> ModifyAsync(long id, PersonalDataForUpdateDto dto);
    Task<IEnumerable<PersonalDataForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
