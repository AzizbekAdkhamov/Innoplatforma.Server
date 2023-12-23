using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;

namespace Innoplatforma.Server.Service.Interfaces.Organizations.Organization;
public interface IOrganizationService
{
    Task<bool> RemoveAsync(long id);
    Task<OrganizationForResultDto> RetrieveByIdAsync(long id);
    Task<OrganizationForResultDto> CreateAsync(OrganizationForCreationDto dto);
    Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto);
    Task<IEnumerable<OrganizationForResultDto>> RetrieveAllAsync(PaginationParams @params);
}