using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Assets;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Domain.Entities.Applications;

public class Application : Auditable<long>
{
    public long UserId { get; set; }
    public User User { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string MotivationLetter { get; set; }
    public int countInvestors { get; set; } = 0;
    public Status Status { get; set; }
    public ApplicationAsset Asset { get; set; }
}
