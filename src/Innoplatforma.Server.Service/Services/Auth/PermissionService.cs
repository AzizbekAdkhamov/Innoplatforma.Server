using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;
using Innoplatforma.Server.Service.Interfaces.Auth;

namespace Innoplatforma.Server.Service.Services.Auth;

public class PermissionService : IPermissionService
{
    private readonly IMapper _mapper;
    private readonly IPermissionRepository _permissionRepository;

    public PermissionService(IMapper mapper, IPermissionRepository permissionRepository)
    {
        _mapper = mapper;
        _permissionRepository = permissionRepository;
    }

    public async Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto)
    {
        var permission = await _permissionRepository.SelectAll()
                .Where(p => p.Name.ToLower() == dto.Name.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (permission is not null)
            throw new InnoplatformException(409, "Permission is already exist.");

        var mappedPermission = _mapper.Map<Permission>(dto);
        mappedPermission.CreatedAt = DateTime.UtcNow;

        var createdPermission = await _permissionRepository.InsertAsync(mappedPermission);

        return _mapper.Map<PermissionForResultDto>(createdPermission);
    }

    public async Task<PermissionForResultDto> ModifyAsync(int id, PermissionForUpdateDto dto)
    {
        var permission = await _permissionRepository.SelectByIdAsync(id);

        if (permission is null)
            throw new InnoplatformException(404, "Permission is not found");

        var mappedPermission = _mapper.Map(dto, permission);
        mappedPermission.UpdatedAt = DateTime.UtcNow;

        await _permissionRepository.UpdateAsync(mappedPermission);

        return _mapper.Map<PermissionForResultDto>(mappedPermission);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var permission = await _permissionRepository.SelectByIdAsync(id);

        if (permission is null)
            throw new InnoplatformException(404, "Permission is not found");

        return await _permissionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var languages = await _permissionRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Permission, int>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<PermissionForResultDto>>(languages);
    }

    public async Task<PermissionForResultDto> RetrieveByIdAsync(int id)
    {
        var permission = await _permissionRepository.SelectByIdAsync(id);

        if (permission is null)
            throw new InnoplatformException(404, "Permission is not found");

        return _mapper.Map<PermissionForResultDto>(permission);
    }
}