using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;
using Innoplatforma.Server.Service.Interfaces.Assets.OrganizationDetailAssets;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Organizations.OrganizationDetails.OrganizationDetailAssets;

public class OrganizationDetailAssetsController : BaseController
{
    private readonly IOrganizationDetailAssetService _organizationDetailAssetService;

    public OrganizationDetailAssetsController(IOrganizationDetailAssetService organizationDetailAssetService)
    {
        _organizationDetailAssetService = organizationDetailAssetService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] OrganizationDetailAssetForCreationDto dto)
        => Ok(await _organizationDetailAssetService.AddAsync(dto));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _organizationDetailAssetService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] long id)
        => Ok(await _organizationDetailAssetService.RemoveAsync(id));

}
