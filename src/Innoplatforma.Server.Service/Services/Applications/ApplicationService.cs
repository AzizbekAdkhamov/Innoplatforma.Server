using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.DTOs.Applications;
using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Service.Interfaces.Applications;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Service.Helpers;
using System.Data.Common;
using Microsoft.IdentityModel.Tokens;

namespace Innoplatforma.Server.Service.Services.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Application, long> _applicationRepository;
    private readonly IUserRepository _userRepository;

    public ApplicationService(
        IMapper mapper,
        IRepository<Application, long> applicationRepository,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task<ApplicationForResultDto> CreateAsync(ApplicationForCreationDto dto)
    {
        var user = await _userRepository.SelectAll()
            .Where(u => u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (!user.IsVerified)
            throw new InnoplatformException(404, "Your passport is not registered");

        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Title.ToLower() == dto.Title.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is not null)
            throw new InnoplatformException(409, "Application alredy exists!");

        var mapped = _mapper.Map<Application>(dto);

        mapped.FilePath = FileUploadHelper.UploadFile("Applications", dto.Asset).Result;
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _applicationRepository.InsertAsync(mapped);

        return _mapper.Map<ApplicationForResultDto>(result);
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var application = await _applicationRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (application is null)
            throw new InnoplatformException(404, "Application is not found!");

        var mapped = _mapper.Map(dto, application);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _applicationRepository.UpdateAsync(mapped);

        return _mapper.Map<ApplicationForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var application = await _applicationRepository.SelectAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (application is null)
            throw new InnoplatformException(404, "Application is not found!");

        await _applicationRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var application = await _applicationRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Application, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(application);
    }

    public async Task<ApplicationForResultDto> RetrieveByIdAsync(long id)
    {
        var application = await _applicationRepository.SelectByIdAsync(id);

        if (application is null)
            throw new InnoplatformException(404, "Application is not found");

        return _mapper.Map<ApplicationForResultDto>(application);
    }
    public async Task<bool> UpdateLogoAsync(long Id, ApplicationForUpdateDto dto)
    {
        var application = await _applicationRepository.SelectAll()
            .Where(a => a.Id == Id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (application is null)
            throw new InnoplatformException(404, "Application is not found!");

        // Delete the existing logo file if needed
        if (!string.IsNullOrEmpty(dto.Asset.Name))
        {
            var existingLogoPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, application.FilePath);
            if (File.Exists(existingLogoPath))
            {
                File.Delete(existingLogoPath);
            }
        }

        application.FilePath = dto.Asset.Name; // Assuming dto.Asset contains the new logo path
        application.UpdatedAt = DateTime.UtcNow;

        var mappedApplication = _mapper.Map<Application>(application);
        var result = await _applicationRepository.UpdateAsync(mappedApplication);

        return true; // Adjust the return type based on your requirements
    }
}
