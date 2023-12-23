using Innoplatforma.Server.Api.Controllers.Commons;
using Microsoft.AspNetCore.Mvc;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.Interfaces.Auth;

namespace Innoplatforma.Server.Api.Controllers.Roles
{
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] RoleForCreationDto dto)
            => Ok(await _roleService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _roleService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] short id)
            => Ok(await _roleService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] short id)
            => Ok(await _roleService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] short id, [FromBody] RoleForUpdateDto dto)
            => Ok(await _roleService.ModifyAsync(id, dto));
    }
}
