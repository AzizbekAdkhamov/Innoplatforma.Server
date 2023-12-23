using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Configurations;

namespace Innoplatforma.Server.Service.Interfaces.Users;

public interface IUsersService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<bool> ChangePasswordAsync(long id, UserForChangePasswordDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword);

}
