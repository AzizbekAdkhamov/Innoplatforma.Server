using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Interfaces.Users;
using Innoplatforma.Server.Service.Services.Accounts.Models;
using Innoplatforma.Server.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Users
{
    public class ChangePasswordsController : BaseController
    {
        private readonly IUsersService _usersService;
        public ChangePasswordsController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPut]
        public async Task<IActionResult> SendMessageAsync(long Id, UserForChangePasswordDto dto)
        => Ok(await _usersService.ChangePasswordAsync(Id,dto));
    }
}
