using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Sections;
using Innoplatforma.Server.Service.Interfaces.Sections;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Sections;

public class SectionsController : BaseController
{
    private readonly ISectionService _sectionService;

    public SectionsController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] SectionForCreationDto dto)
        => Ok(await _sectionService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _sectionService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] short id)
        => Ok(await _sectionService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] short id)
        => Ok(await _sectionService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] short id, [FromBody] SectionForUpdateDto dto)
        => Ok(await _sectionService.ModifyAsync(id, dto));
}
