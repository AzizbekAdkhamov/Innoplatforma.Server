using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Interfaces.Professions;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;


namespace Innoplatforma.Server.Service.Services.Users;

public class UserProfessionService : IUserProfessionService
{
    private readonly IMapper _mapper;
    private readonly IUserProfessionRepository _userProfessionRepository;

    public UserProfessionService(IMapper mapper, IUserProfessionRepository userProfessionRepository)
    {
        _mapper = mapper;
        _userProfessionRepository = userProfessionRepository;
    }

    public async Task<UserProfessionForResultDto> CreateAsync(UserProfessionForCreationDto dto)
    {
        var userProfession = await _userProfessionRepository.SelectAll()
            .Where(up => up.UserId == dto.UserId && up.ProfessionId == dto.ProfessionId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (userProfession is not null)
            throw new InnoplatformException(409, "UserProfession is already exist.");

        var mapUserProfession = _mapper.Map<UserProfession>(dto);
        mapUserProfession.CreatedAt = DateTime.UtcNow;

        var createdUserProfession = await _userProfessionRepository.InsertAsync(mapUserProfession);

        return _mapper.Map<UserProfessionForResultDto>(createdUserProfession);
    }

    public async Task<UserProfessionForResultDto> ModifyAsync(long id, UserProfessionForUpdateDto dto)
    {
        var userProfession = await _userProfessionRepository.SelectByIdAsync(id);

        if (userProfession is null)
            throw new InnoplatformException(404, "UserProfession is not found");

        var mappedUser = _mapper.Map(dto, userProfession);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        await _userProfessionRepository.UpdateAsync(mappedUser);

        return _mapper.Map<UserProfessionForResultDto>(mappedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _userProfessionRepository.SelectByIdAsync(id);

        if (user is null)
            throw new InnoplatformException(404, "UserProfession is not found");

        return await _userProfessionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserProfessionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var user = await _userProfessionRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList<UserProfession, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserProfessionForResultDto>>(user);
    }

    public async Task<UserProfessionForResultDto> RetrieveByIdAsync(long id)
    {
        var userProfession = await _userProfessionRepository.SelectByIdAsync(id);

        if (userProfession is null)
            throw new InnoplatformException(404, "UserProfession is not found");

        return _mapper.Map<UserProfessionForResultDto>(userProfession);
    }
}

