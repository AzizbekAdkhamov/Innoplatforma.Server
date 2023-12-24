using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Service.Interfaces.Professions;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;
using Innoplatforma.Server.Service.DTOs.Professions;
using Innoplatforma.Server.Service.Commons.Extentions;

namespace Innoplatforma.Server.Service.Services.Professions;

public class ProfessionService : IProfessionService
{
    private readonly IMapper _mapper;
    private readonly IProfessionRepository _professionRepository;

    public ProfessionService(IMapper mapper, IProfessionRepository professionRepository)
    {
        _mapper = mapper;
        _professionRepository = professionRepository;
    }

    public async Task<ProfessionForResultDto> CreateAsync(ProfessionForCreatedDto dto)
    {
        var profession = await _professionRepository.SelectAll()
            .Where(p => p.Name == dto.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (profession is not null)
            throw new InnoplatformException(409, "profession is already exist.");

        var mapProfession = _mapper.Map<Profession>(dto);
        mapProfession.CreatedAt = DateTime.UtcNow;

        var createdProfession = await _professionRepository.InsertAsync(mapProfession);

        return _mapper.Map<ProfessionForResultDto>(createdProfession);
    }

    public async Task<ProfessionForResultDto> ModifyAsync(int id, ProfessionForUpdateDto dto)
    {
        var profession = await _professionRepository.SelectByIdAsync(id);

        if (profession is null)
            throw new InnoplatformException(404, "Profession is not found");

        var mappedUser = _mapper.Map(dto, profession);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        await _professionRepository.UpdateAsync(mappedUser);

        return _mapper.Map<ProfessionForResultDto>(mappedUser);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var user = await _professionRepository.SelectByIdAsync(id);

        if (user is null)
            throw new InnoplatformException(404, "Profession is not found");

        return await _professionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProfessionForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var profession = await _professionRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList<Profession, int>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProfessionForResultDto>>(profession);
    }

    public async Task<ProfessionForResultDto> RetrieveByIdAsync(int id)
    {
        var profession = await _professionRepository.SelectByIdAsync(id);

        if (profession is null)
            throw new InnoplatformException(404, "Profession is not found");

        return _mapper.Map<ProfessionForResultDto>(profession);
    }
}
