 using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;
using Innoplatforma.Server.Service.Interfaces.Organizations.Organization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Organizations;

[EnableRateLimiting("fixed")]
public class OrganizationsController : BaseController
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] OrganizationForCreationDto dto)
        => Ok(await _organizationService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _organizationService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _organizationService.RetrieveByIdAsync(id));

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] long id)
        => Ok(await _organizationService.RemoveAsync(id));

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] OrganizationForUpdateDto dto)
        => Ok(await _organizationService.ModifyAsync(id, dto));
}
