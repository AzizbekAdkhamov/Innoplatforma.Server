using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Users;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class PersonalDataAssets : Auditable<long>
{
    public long PersonalDataId {  get; set; } 
    public PersonalData PersonalData { get; set; }
}
