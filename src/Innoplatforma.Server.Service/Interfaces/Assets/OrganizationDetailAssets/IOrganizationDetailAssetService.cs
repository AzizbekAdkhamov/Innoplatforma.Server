
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;

namespace Innoplatforma.Server.Service.Interfaces.Assets.OrganizationDetailAssets;

public interface IOrganizationDetailAssetService
{
    Task<bool> RemoveAsync(long id);
    Task<OrganizationDetailAssetForResultDto> RetrieveByIdAsync(long id);
    Task<OrganizationDetailAssetForResultDto> AddAsync(OrganizationDetailAssetForCreationDto dto);
}