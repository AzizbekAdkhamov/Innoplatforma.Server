using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Service.DTOs.Investments;

public class InvestmentForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long ApplicationId { get; set; }
    public Status Status { get; set; }
}
