using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Professions;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;
using Innoplatforma.Server.Service.Interfaces.Professions;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.UserProfessions;

public class UserProfessionsController : BaseController
{
    private readonly IUserProfessionService _userProfessionService;

    public UserProfessionsController(IUserProfessionService userProfessionService)
    {
        _userProfessionService = userProfessionService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] UserProfessionForCreationDto dto)
        => Ok(await _userProfessionService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userProfessionService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        => Ok(await _userProfessionService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        => Ok(await _userProfessionService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserProfessionForUpdateDto dto)
        => Ok(await _userProfessionService.ModifyAsync(id, dto));
}
