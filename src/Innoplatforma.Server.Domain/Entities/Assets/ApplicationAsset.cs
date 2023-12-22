using Innoplatforma.Server.Domain.Entities.Applications;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class ApplicationAsset : Asset
{
    public long ApplicationId { get; set; }
    public Application Application { get; set; }
}
