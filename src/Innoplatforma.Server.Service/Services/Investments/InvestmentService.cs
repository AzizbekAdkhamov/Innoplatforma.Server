using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Investments;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Service.Interfaces.Investments;

namespace Innoplatforma.Server.Service.Services.Investments;

public class InvestmentService : IInvestmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Investment, long> investmentRepository;

    public InvestmentService(
        IMapper mapper,
        IRepository<Investment, long> investmentRepository)
    {
        this.mapper = mapper;
        this.investmentRepository = investmentRepository;
    }
    public async Task<InvestmentForResultDto> AddAsync(InvestmentForCreateDto dto)
    {
        var investment = await investmentRepository.SelectAll()
                .Where(i => i.ApplicationId == dto.ApplicationId 
                    && i.UserId == dto.UserId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (investment is not null)
            throw new InnoplatformException(409, "Investment alredy exists!");

        var mapped = mapper.Map<Investment>(dto);

        var result = await investmentRepository.InsertAsync(mapped);

        return mapper.Map<InvestmentForResultDto>(result);
    }

    public async Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto)
    {
        var investment = await investmentRepository.SelectAll()
            .Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found!");

        var mapped = mapper.Map(dto, investment);
        mapped.UpdatedAt = DateTime.UtcNow;

        await investmentRepository.UpdateAsync(mapped);

        return mapper.Map<InvestmentForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var investment = await investmentRepository.SelectAll()
            .Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found!");

        await investmentRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<InvestmentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var investment = await investmentRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Investment, long>(@params)
            .ToListAsync();

        return mapper.Map<IEnumerable<InvestmentForResultDto>>(investment);
    }

    public async Task<InvestmentForResultDto> RetrieveByIdAsync(long id)
    {
        var investment = await investmentRepository.SelectByIdAsync(id);

        if (investment is null)
            throw new InnoplatformException(404, "Investment is not found");

        return mapper.Map<InvestmentForResultDto>(investment);
    }
}
