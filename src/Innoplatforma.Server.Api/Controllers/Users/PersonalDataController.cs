using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;
using Innoplatforma.Server.Service.Services.Users.PersonalDatas;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Users;

public class PersonalDataController : BaseController
{
    private readonly IPersonalDataService _personalData;

    public PersonalDataController(IPersonalDataService personalData)
    {
        _personalData = personalData;
    }

    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromForm] PersonalDataForCreationDto dto)
            => Ok(await _personalData.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
       => Ok(await _personalData.RetrieveAllAsync(@params));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromForm] PersonalDataForUpdateDto dto)
            => Ok(await _personalData.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _personalData.RemoveAsync(id));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await _personalData.RetrieveByIdAsync(id));
}
