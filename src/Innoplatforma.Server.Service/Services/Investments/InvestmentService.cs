using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Investments;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Service.Interfaces.Investments;

namespace Innoplatforma.Server.Service.Services.Investments;

public class InvestmentService : IInvestmentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User, long> _userRepository; 
    private readonly IRepository<Investment, long> _investmentRepository;
    private readonly IRepository<Application, long> _apllicationRepository;

    public InvestmentService(
        IMapper mapper,
        IRepository<User, long> userRepository,
        IRepository<Investment, long> investmentRepository,
        IRepository<Application, long> apllicationRepository
        )
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _investmentRepository = investmentRepository;
        _apllicationRepository = apllicationRepository;
    }
    public async Task<InvestmentForResultDto> AddAsync(InvestmentForCreateDto dto)
    {
        var investment = await _investmentRepository.SelectAll()
                .Where(i => i.ApplicationId == dto.ApplicationId 
                    && i.UserId == dto.UserId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (investment is not null)
            throw new InnoplatformException(409, "Investment alredy exists!");

        var mapped = _mapper.Map<Investment>(dto);

        var result = await _investmentRepository.InsertAsync(mapped);

        return _mapper.Map<InvestmentForResultDto>(result);
    }

    public async Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto)
    {
        var investment = await _investmentRepository.SelectAll()
            .Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found!");

        var mapped = _mapper.Map(dto, investment);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _investmentRepository.UpdateAsync(mapped);

        return _mapper.Map<InvestmentForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var investment = await _investmentRepository.SelectAll()
            .Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found!");

        await _investmentRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<InvestmentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var investment = await _investmentRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Investment, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<InvestmentForResultDto>>(investment);
    }

    public async Task<InvestmentForResultDto> RetrieveByIdAsync(long id)
    {
        var investment = await _investmentRepository.SelectByIdAsync(id);

        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found");

        return _mapper.Map<InvestmentForResultDto>(investment);
    }
}
