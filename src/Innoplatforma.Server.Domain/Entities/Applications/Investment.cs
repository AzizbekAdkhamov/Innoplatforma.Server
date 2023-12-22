using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Domain.Entities.Applications;

public class Investment : Auditable<long>
{
    public long ApplicationId { get; set; }
    public Application Application { get; set; }
    public Status Status { get; set; }
}
