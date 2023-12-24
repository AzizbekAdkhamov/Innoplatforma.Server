﻿using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;
using Innoplatforma.Server.Service.Interfaces.Organizations.OrganizationDetails;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Organizations.OrganizationDetails;

public class OrganizationDetailsController : BaseController
{
    private readonly IOrganizationDetailService _organizationDetailService;

    public OrganizationDetailsController(IOrganizationDetailService organizationDetailService)
    {
        _organizationDetailService = organizationDetailService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] OrganizationDetailForCreationDto dto)
        => Ok(await _organizationDetailService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _organizationDetailService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _organizationDetailService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] OrganizationDetailForUpdateDto dto)
        => Ok(await _organizationDetailService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] long id)
        => Ok(await _organizationDetailService.RemoveAsync(id));

    [HttpPatch("{id}")] 
    public async Task<IActionResult> UpdateLogoAsync([FromRoute(Name = "id")] long id, IFormFile formFile)
        => Ok(await _organizationDetailService.UpdateLogoAsync(id, formFile));


    [HttpDelete("asset-update {id}")]
    public async Task<IActionResult> DeleteLogoAsync([FromRoute(Name = "id")] long id)
        => Ok(await _organizationDetailService.RemoveLogoAsync(id));
}