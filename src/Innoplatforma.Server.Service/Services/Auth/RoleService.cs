using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Service.Commons.Extentions;

namespace Innoplatforma.Server.Service.Services.Auth;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<RoleForResultDto> CreateAsync(RoleForCreationDto dto)
    {
        var role = await _roleRepository
            .SelectAll()
            .Where(r => r.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (role is not null)
            throw new InnoplatformException(409, "Role is already exist!");
        var mapRole = _mapper.Map<Role>(dto);
        mapRole.CreatedAt = DateTime.UtcNow;

        var createdRole = await _roleRepository.InsertAsync(mapRole);
        return _mapper.Map<RoleForResultDto>(createdRole);
    }

    public async Task<RoleForResultDto> ModifyAsync(short id, RoleForUpdateDto dto)
    {
        var role = await _roleRepository.SelectByIdAsync(id);

        if (role is null)
            throw new InnoplatformException(404, "role is not found");

        var mappedRole = _mapper.Map(dto, role);
        mappedRole.UpdatedAt = DateTime.UtcNow;

        await _roleRepository.UpdateAsync(mappedRole);

        return _mapper.Map<RoleForResultDto>(mappedRole);
    }

    public async Task<bool> RemoveAsync(short id)
    {
        var role = await _roleRepository.SelectByIdAsync(id);

        if (role is null)
            throw new InnoplatformException(404, "Role is not found");

        return await _roleRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var role = await _roleRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Role, short>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<RoleForResultDto>>(role);
    }

    public async Task<RoleForResultDto> RetrieveByIdAsync(short id)
    {
        var role = await _roleRepository.SelectByIdAsync(id);

        if (role is null)
            throw new InnoplatformException(404, "Role is not found");

        return _mapper.Map<RoleForResultDto>(role);
    }
}
