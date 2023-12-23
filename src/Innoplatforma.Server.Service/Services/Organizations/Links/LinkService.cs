using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Service.DTOs.Organizations.Links;
using Innoplatforma.Server.Service.Interfaces.Organizations.Links;
using Innoplatforma.Server.Data.IRepositories.Organizations.Links;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;

namespace Innoplatforma.Server.Service.Services.Organizations.Links;

public class LinkService : ILinkService
{
    private readonly IMapper _mapper;
    private readonly ILinkRepository _linkRepository;
    private readonly IOrganizationDetailRepository _organizationDetailRepository;

    public LinkService(IMapper mapper, ILinkRepository linkRepository, IOrganizationDetailRepository organizationDetailRepository)
    {
        _mapper = mapper;
        _linkRepository = linkRepository;
        _organizationDetailRepository = organizationDetailRepository;
    }

    public async Task<LinkForResultDto> CreateAsync(LinkForCreationDto dto)
    {
        var organization = await _organizationDetailRepository.SelectAll()
                .Where(orgd => orgd.Id == dto.OrganizationDetailId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (organization is null)
            throw new InnoplatformException(404, "Organization is not found");

        var link = await _linkRepository.SelectAll()
                .Where(l => l.LinkUrl.ToLower() == dto.LinkUrl.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (link is not null)
            throw new InnoplatformException(409, "Link is already exist.");

        var mappedLink = _mapper.Map<Link>(dto);
        mappedLink.CreatedAt = DateTime.UtcNow;

        var createdLink = await _linkRepository.InsertAsync(mappedLink);

        return _mapper.Map<LinkForResultDto>(createdLink);
    }

    public async Task<LinkForResultDto> ModifyAsync(long id, LinkForUpdateDto dto)
    {
        var organization = await _organizationDetailRepository.SelectAll()
        .Where(orgd => orgd.Id == dto.OrganizationDetailId)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        if (organization is null)
            throw new InnoplatformException(404, "Link is not found");

        var link = await _linkRepository.SelectByIdAsync(id);

        if (link is null)
            throw new InnoplatformException(404, "Link is not found");

        var mappedLink = _mapper.Map(dto, link);
        mappedLink.UpdatedAt = DateTime.UtcNow;

        await _linkRepository.UpdateAsync(mappedLink);

        return _mapper.Map<LinkForResultDto>(mappedLink);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var permission = await _linkRepository.SelectByIdAsync(id);

        if (permission is null)
            throw new InnoplatformException(404, "Permission is not found");

        return await _linkRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LinkForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var links = await _linkRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Link, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LinkForResultDto>>(links);
    }

    public async Task<LinkForResultDto> RetrieveByIdAsync(long id)
    {
        var link = await _linkRepository.SelectByIdAsync(id);

        if (link is null)
            throw new InnoplatformException(404, "Link is not found");

        return _mapper.Map<LinkForResultDto>(link);
    }
}