using Microsoft.AspNetCore.Mvc;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;

namespace Innoplatforma.Server.Api.Controllers.Auth;

public class PermissionsController : BaseController
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] PermissionForCreationDto dto)
        => Ok(await _permissionService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _permissionService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        => Ok(await _permissionService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        => Ok(await _permissionService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] PermissionForUpdateDto dto)
        => Ok(await _permissionService.ModifyAsync(id, dto));
}