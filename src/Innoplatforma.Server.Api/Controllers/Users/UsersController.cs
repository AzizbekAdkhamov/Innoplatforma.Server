using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Sections;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Users
{

    [EnableRateLimiting("fixed")]

    public class UsersController : BaseController
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] UserForCreationDto dto)
            => Ok(await _usersService.CreateAsync(dto));

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
       => Ok(await _usersService.RetrieveAllAsync(@params));

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _usersService.RetrieveByIdAsync(id));

        [Authorize(Roles = "User , Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _usersService.RemoveAsync(id));

        [Authorize(Roles = "User, Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UserForUpdateDto dto)
            => Ok(await _usersService.ModifyAsync(id, dto));
    }
}
