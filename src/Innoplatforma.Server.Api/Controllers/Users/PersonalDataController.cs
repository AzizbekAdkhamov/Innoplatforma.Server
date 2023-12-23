using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;
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

}
