using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Applications;
using Innoplatforma.Server.Service.DTOs.Investments;

namespace Innoplatforma.Server.Service.Interfaces.Investments;

public interface IInvestmentService
{
    Task<bool> RemoveAsync(long id);
    Task<InvestmentForResultDto> RetrieveByIdAsync(long id);
    Task<InvestmentForResultDto> AddAsync(InvestmentForCreateDto dto);
    Task<InvestmentForResultDto> ModifyAsync(long id, InvestmentForUpdateDto dto);
    Task<IEnumerable<InvestmentForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
