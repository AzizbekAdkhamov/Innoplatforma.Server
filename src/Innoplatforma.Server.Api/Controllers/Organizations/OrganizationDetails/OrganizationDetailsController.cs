using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;
using Innoplatforma.Server.Service.Interfaces.Organizations.OrganizationDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Organizations.OrganizationDetails;

[EnableRateLimiting("fixed")]
public class OrganizationDetailsController : BaseController
{
    private readonly IOrganizationDetailService _organizationDetailService;

    public OrganizationDetailsController(IOrganizationDetailService organizationDetailService)
    {
        _organizationDetailService = organizationDetailService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] OrganizationDetailForCreationDto dto)
        => Ok(await _organizationDetailService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _organizationDetailService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _organizationDetailService.RetrieveByIdAsync(id));

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] OrganizationDetailForUpdateDto dto)
        => Ok(await _organizationDetailService.ModifyAsync(id, dto));

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] long id)
        => Ok(await _organizationDetailService.RemoveAsync(id));

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}")] 
    public async Task<IActionResult> UpdateLogoAsync([FromRoute(Name = "id")] long id, IFormFile formFile)
        => Ok(await _organizationDetailService.UpdateLogoAsync(id, formFile));

    [Authorize(Roles = "Admin")]
    [HttpDelete("esset/{id}")]
    public async Task<IActionResult> DeleteLogoAsync([FromRoute(Name = "id")] long id)
        => Ok(await _organizationDetailService.RemoveLogoAsync(id));
}
