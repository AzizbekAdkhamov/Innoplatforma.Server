using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Sections;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Users
{
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
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
       => Ok(await _usersService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _usersService.RetrieveByIdAsync(id));

        [HttpGet("CheckUser/{telegramId}")]
        public async Task<IActionResult> GetByTelegramIdAsync([FromRoute] long telegramId)
            => Ok(await _usersService.RetrieveByTelegramIdAsync(telegramId));

        [HttpGet("phone-number")]
        public async Task<IActionResult> RetrievePhoneNumberAsync(string phoneNumber)
            => Ok(await _usersService.RetrieveByPhoneNumberAsync(phoneNumber));


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _usersService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UserForUpdateDto dto)
            => Ok(await _usersService.ModifyAsync(id, dto));

        [HttpPut("{id}/telegram/{telegramId}")]
        public async Task<IActionResult> UpdateTelegramIdAsync([FromRoute] long id, [FromRoute] long telegramId)
            => Ok(await _usersService.ModifyTelegramId(id, telegramId));
    }
}
