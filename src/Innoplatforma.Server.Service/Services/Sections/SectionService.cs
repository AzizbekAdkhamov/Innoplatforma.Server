using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.DTOs.Sections;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Domain.Entities.Sections;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Interfaces.Sections;
using Innoplatforma.Server.Data.IRepositories.Sections;

namespace Innoplatforma.Server.Service.Services.Sections;

public class SectionService : ISectionService
{
    private readonly IMapper _mapper;
    private readonly ISectionRepository _sectionRepository;

    public SectionService(IMapper mapper, ISectionRepository sectionRepository)
    {
        _mapper = mapper;
        _sectionRepository = sectionRepository;
    }

    public async Task<SectionForResultDto> CreateAsync(SectionForCreationDto dto)
    {
        var section = await _sectionRepository.SelectAll()
                .Where(p => p.Title.ToLower() == dto.Title.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (section is not null)
            throw new InnoplatformException(409, "Sections is already exist.");

        var mappedSection = _mapper.Map<Section>(dto);
        mappedSection.CreatedAt = DateTime.UtcNow;

        var createdSection = await _sectionRepository.InsertAsync(mappedSection);

        return _mapper.Map<SectionForResultDto>(createdSection);
    }

    public async Task<SectionForResultDto> ModifyAsync(short id, SectionForUpdateDto dto)
    {
        var section = await _sectionRepository.SelectByIdAsync(id);

        if (section is null)
            throw new InnoplatformException(404, "Section is not found");

        var mappedSection = _mapper.Map(dto, section);
        mappedSection.UpdatedAt = DateTime.UtcNow;

        await _sectionRepository.UpdateAsync(mappedSection);

        return _mapper.Map<SectionForResultDto>(mappedSection);
    }

    public async Task<bool> RemoveAsync(short id)
    {
        var section = await _sectionRepository.SelectByIdAsync(id);

        if (section is null)
            throw new InnoplatformException(404, "Section is not found");

        return await _sectionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SectionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var section = await _sectionRepository.SelectAll()
            .Include(s => s.Organizations)
            .AsNoTracking()
            .ToPagedList<Section, short>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<SectionForResultDto>>(section);
    }

    public async Task<SectionForResultDto> RetrieveByIdAsync(short id)
    {
        var section = await _sectionRepository.SelectByIdAsync(id);

        if (section is null)
            throw new InnoplatformException(404, "Section is not found");

        return _mapper.Map<SectionForResultDto>(section);
    }
}
