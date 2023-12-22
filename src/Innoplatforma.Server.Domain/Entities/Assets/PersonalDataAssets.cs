using Innoplatforma.Server.Domain.Entities.Users;

namespace Innoplatforma.Server.Domain.Entities.Assets;

public class PersonalDataAssets
{
    public long PersonalDataId {  get; set; } 
    public PersonalData PersonalData { get; set; }
}
