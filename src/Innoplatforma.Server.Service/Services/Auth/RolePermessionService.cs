using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.DTOs.Auth.RolePermissions;

namespace Innoplatforma.Server.Service.Services.Auth;

public class RolePermessionService : IRolePermessionService
{
    private readonly IMapper _mapper;
    private readonly IRolePermessionRepository _rolePermessionRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;

    public RolePermessionService(IRolePermessionRepository rolePermession, IMapper mapper, IPermissionRepository permissionRepository, IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _roleRepository = roleRepository;
        _rolePermessionRepository = rolePermession;
        _permissionRepository = permissionRepository;
    }

    public async Task<RolePermessionForResultDto> CreateAsync(RolePermissionForCreationDto dto)
    {
        var rolePermession = await _rolePermessionRepository
            .SelectAll()
            .Where(rp => rp.RoleId == dto.RoleId && rp.PremessionId == dto.PermessionId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (rolePermession is not null)
            throw new InnoplatformException(409, "RolePermession is already exist!");

        var mapRolePermession = _mapper.Map<RolePermession>(dto);
        mapRolePermession.CreatedAt = DateTime.UtcNow;

        var createdRolePermession = await _rolePermessionRepository.InsertAsync(mapRolePermession);
        return _mapper.Map<RolePermessionForResultDto>(createdRolePermession);
    }

    public async Task<RolePermessionForResultDto> ModifyAsync(long id, RolePermissionForUpdateDto dto)
    {
        var rolePermession = await _rolePermessionRepository.SelectByIdAsync(id);

        if (rolePermession is null)
            throw new InnoplatformException(404, "RolePermession is not found");

        var mappedRolePermession = _mapper.Map(dto, rolePermession);
        mappedRolePermession.UpdatedAt = DateTime.UtcNow;

        await _rolePermessionRepository.UpdateAsync(mappedRolePermession);

        return _mapper.Map<RolePermessionForResultDto>(mappedRolePermession);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var rolePermission = await _rolePermessionRepository.SelectByIdAsync(id);

        if (rolePermission is null)
            throw new InnoplatformException(404, "RolePermission is not found");

        return await _rolePermessionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<RolePermessionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var rolePermession = await _rolePermessionRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<RolePermession, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<RolePermessionForResultDto>>(rolePermession);
    }

    public async Task<RolePermessionForResultDto> RetrieveByIdAsync(long id)
    {
        var rolePermession = await _rolePermessionRepository.SelectByIdAsync(id);

        if (rolePermession is null)
            throw new InnoplatformException(404, "RolePermession is not found");

        return _mapper.Map<RolePermessionForResultDto>(rolePermession);
    }
}
