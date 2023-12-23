using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Service.Interfaces.Organizations.OrganizationDetails;

namespace Innoplatforma.Server.Service.Services.Organizations.OrganizationDetails;

public class OrganizationDetailService : IOrganizationDetailService
{
    private readonly IOrganizationDetailRepository _organizationDetailRepository;
    private readonly IMapper _mapper;

    public OrganizationDetailService(IOrganizationDetailRepository organizationDetailRepository)
    {
        _organizationDetailRepository = organizationDetailRepository;
    }
}
