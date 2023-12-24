using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Configurations;

namespace Innoplatforma.Server.Service.Interfaces.Users;

public interface IUsersService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyTelegramId(long id, long telegramId);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<UserForResultDto> RetrieveByTelegramIdAsync(long telegramId);
    Task<bool> ChangePasswordAsync(long id, UserForChangePasswordDto dto);
    Task<UserForResultDto> RetrieveByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword);

}
