﻿using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;

namespace Innoplatforma.Server.Service.Interfaces.Organizations.OrganizationDetails;

public interface IOrganizationDetailService
{
    Task<bool> RemoveAsync(long id);
    Task<OrganizationDetailForResultDto> RetrieveByIdAsync(long id);
    Task<OrganizationDetailForResultDto> CreateAsync(OrganizationDetailForCreationDto dto);
    Task<OrganizationDetailForResultDto> ModifyAsync(long id, OrganizationDetailForUpdateDto dto);
    Task<IEnumerable<OrganizationDetailForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
