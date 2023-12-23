using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Organizations;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Data.IRepositories.References;
using Innoplatforma.Server.Data.IRepositories.Sections;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Interfaces.Organizations.Organization;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Service.Services.Organizations;

public class OrganizationService : IOrganizationService
{
    private readonly IMapper _mapper;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationDetailRepository _organizationDetailRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ISectionRepository _sectionRepository;

    public OrganizationService(IMapper mapper, 
        IOrganizationRepository organizationRepository, 
        IOrganizationDetailRepository organizationDetailRepository, 
        ISectionRepository sectionRepository, 
        ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _organizationRepository = organizationRepository;
        _organizationDetailRepository = organizationDetailRepository;
        _sectionRepository = sectionRepository;
        _locationRepository = locationRepository;
    }

    public async Task<OrganizationForResultDto> CreateAsync(OrganizationForCreationDto dto)
    {
        var section = await _sectionRepository.SelectAll()
                .Where(s => s.Id == dto.SectionId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (section is null)
            throw new InnoplatformException(404, "Section is not found");


        var location = await _locationRepository.SelectAll()
                    .Where(l => l.Id == dto.LocationId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        if (location is null)
            throw new InnoplatformException(404, "Location is not found");

        var organization = await _organizationRepository.SelectAll()
            .Where(org => org.Name == dto.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (organization is not null)
            throw new InnoplatformException(409, "Organization is already exist.");

        var mappedOrganization = _mapper.Map<Organization>(dto);
        mappedOrganization.CreatedAt = DateTime.UtcNow;

        var createdOrganization = await _organizationRepository.InsertAsync(mappedOrganization);

        return _mapper.Map<OrganizationForResultDto>(createdOrganization);
    }

    public async Task<OrganizationForResultDto> ModifyAsync(long id, OrganizationForUpdateDto dto)
    {
        var section = await _sectionRepository.SelectAll()
                .Where(s => s.Id == dto.SectionId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (section is null)
            throw new InnoplatformException(404, "Section is not found");


        var location = await _locationRepository.SelectAll()
                    .Where(l => l.Id == dto.LocationId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        if (location is null)
            throw new InnoplatformException(404, "Location is not found");

        var organization = await _organizationRepository.SelectByIdAsync(id);
        if (organization is null)
            throw new InnoplatformException(404, "Organization is not found");

        var mappedOrganization = _mapper.Map(dto, organization);
        mappedOrganization.UpdatedAt = DateTime.UtcNow;

        await _organizationRepository.UpdateAsync(mappedOrganization);

        return _mapper.Map<OrganizationForResultDto>(mappedOrganization);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var organization = await _organizationRepository.SelectByIdAsync(id);

        if (organization is null)
            throw new InnoplatformException(404, "Organization is not found");

        return await _organizationRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrganizationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var organizations = await _organizationRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Organization, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrganizationForResultDto>>(organizations);
    }

    public async Task<OrganizationForResultDto> RetrieveByIdAsync(long id)
    {
        var organization = await _organizationRepository.SelectByIdAsync(id);

        if (organization is null)
            throw new InnoplatformException(404, "Organization is not found");

        return _mapper.Map<OrganizationForResultDto>(organization);
    }
}
