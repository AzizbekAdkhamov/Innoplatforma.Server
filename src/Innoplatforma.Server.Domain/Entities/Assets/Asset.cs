using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class Asset : Auditable<long>
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public string Type { get; set; }
    public string Path { get; set; }
    public long Size { get; set; }
}
