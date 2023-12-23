using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

namespace Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;

public interface IPersonalDataService
{
    Task<bool> RemoveAsync(long id);
    Task<PersonalDataForResultDto> RetrieveByIdAsync(long id);
    Task<PersonalDataForResultDto> CreateAsync(PersonalDataForCreationDto dto);
    Task<PersonalDataForResultDto> ModifyAsync(long id, PersonalDataForUpdateDto dto);
}
