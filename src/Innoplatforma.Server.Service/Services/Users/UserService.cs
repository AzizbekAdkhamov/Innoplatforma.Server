using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Commons.Helpers;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Service.Services.Users;

public class UserService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<bool> ChangePasswordAsync(long id, UserForChangePasswordDto dto)
    {
        var user = await _userRepository
            .SelectAll()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();

        if (user is null || !PasswordHelper.Verify(dto.OldPassword, user.Salt, user.Password))
            throw new InnoplatformException(404, "User or Password is incorrect");

        else if (dto.NewPassword != dto.ConfirmPassword)
            throw new InnoplatformException(400, "New password and confir password aren't equal");

        var hash = PasswordHelper.Hash(dto.ConfirmPassword);
        user.Salt = hash.Salt;
        user.Password = hash.Hash;
        var updated = _userRepository.UpdateAsync(user);

        return true;
    }

    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Email == dto.Email || u.Phone == dto.Phone)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is not null)
            throw new InnoplatformException(409, "User is already exist.");

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.Salt = hasherResult.Salt.ToString();
        mappedUser.Password = hasherResult.Hash;

        var createdUser = await _userRepository.InsertAsync(mappedUser);

        return _mapper.Map<UserForResultDto>(createdUser);
    }

    public async Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Phone.ToString() == PhoneNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "User not found");

        if (NewPassword != ConfirmPassword)
            throw new InnoplatformException(400, "New password and confirm password aren't equal");

        var hash = PasswordHelper.Hash(NewPassword);

        user.Salt = hash.Salt;
        user.Password = hash.Hash;

        var updated = _userRepository.UpdateAsync(user);

        return true;
    }


    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await _userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new InnoplatformException(404, "User is not found");

        var mappedUser = _mapper.Map(dto, user);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(mappedUser);

        return _mapper.Map<UserForResultDto>(mappedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new InnoplatformException(404, "User is not found");

        return await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var user = await _userRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<User, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserForResultDto>>(user);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await _userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new InnoplatformException(404, "User is not found");

        return _mapper.Map<UserForResultDto>(user);
    }
}
