using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Users;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class PersonalDataAssets : Auditable<long>
{
    public long PersonalDataId {  get; set; }
    public long AssetId { get; set; }
    public Asset Asset { get; set; }

}
