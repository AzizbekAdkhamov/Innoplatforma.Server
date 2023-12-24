using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;
using Innoplatforma.Server.Service.DTOs.Auth.RolePermissions;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Auth;

public class RolePermessionsController : BaseController
{
    private readonly IRolePermessionService _rolePermessionService;
    public RolePermessionsController(IRolePermessionService permissionService)
    {
        _rolePermessionService = permissionService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] RolePermissionForCreationDto dto)
        => Ok(await _rolePermessionService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _rolePermessionService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        => Ok(await _rolePermessionService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        => Ok(await _rolePermessionService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] RolePermissionForUpdateDto dto)
        => Ok(await _rolePermessionService.ModifyAsync(id, dto));
}
