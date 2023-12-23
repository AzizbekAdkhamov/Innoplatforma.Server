using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Service.DTOs.Investments;

public class InvestmentForUpdateDto
{
    public long UserId { get; set; }
    public long ApplicationId { get; set; }
    public Status Status { get; set; }
}
