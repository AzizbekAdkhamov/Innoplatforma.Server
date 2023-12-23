using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;

namespace Innoplatforma.Server.Service.Interfaces.Organizations.Organization;
public interface IOrganizationService
{
    Task<bool> RemoveAsync(long id);
    Task<OrganizationDetailAssetForResultDto> RetrieveByIdAsync(long id);
    Task<OrganizationDetailAssetForResultDto> CreateAsync(OrganizationDetailAssetForCreationDto dto);
    Task<OrganizationDetailAssetForResultDto> ModifyAsync(long id, OrganizationDetailAssetForUpdateDto dto);
    Task<IEnumerable<OrganizationDetailAssetForResultDto>> RetrieveAllAsync(PaginationParams @params);
}