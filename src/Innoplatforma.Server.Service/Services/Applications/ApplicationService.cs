using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.DTOs.Applications;
using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Service.Interfaces.Applications;

namespace Innoplatforma.Server.Service.Services.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IMapper mapper;
    private readonly IRepository<Application, long> applicationRepository;

    public ApplicationService(
        IMapper mapper,
        IRepository<Application, long> applicationRepository)
    {
        this.mapper = mapper;
        this.applicationRepository = applicationRepository; 
    }

    public async Task<ApplicationForResultDto> CreateAsync(ApplicationForCreationDto dto)
    {
        var application = await applicationRepository.SelectAll()
                .Where(a => a.Title.ToLower() == dto.Title.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is not null)
            throw new InnoplatformException(409, "Application alredy exists!");

        var mapped = mapper.Map<Application>(dto);

        var result = await applicationRepository.InsertAsync(mapped);

        return mapper.Map<ApplicationForResultDto>(result);
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var application = await applicationRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (application is null)
            throw new InnoplatformException(404, "Application is not found!");

        var mapped = mapper.Map(dto, application);
        mapped.UpdatedAt = DateTime.UtcNow;

        await applicationRepository.UpdateAsync(mapped);

        return mapper.Map<ApplicationForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var application = await applicationRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (application is null)
            throw new InnoplatformException(404, "Application is not found!");

        await applicationRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var application = await applicationRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Application, long>(@params)
            .ToListAsync();

        return mapper.Map<IEnumerable<ApplicationForResultDto>>(application);
    }

    public async Task<ApplicationForResultDto> RetrieveByIdAsync(long id)
    {
        var application = await applicationRepository.SelectByIdAsync(id);

        if (application is null)
            throw new InnoplatformException(404, "Application is not found");

        return mapper.Map<ApplicationForResultDto>(application);
    }
}
