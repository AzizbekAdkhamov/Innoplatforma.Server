using Microsoft.AspNetCore.Http;

namespace Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;

public class OrganizationDetailAssetForCreationDto
{
    public IFormFile formFile {  get; set; }
}