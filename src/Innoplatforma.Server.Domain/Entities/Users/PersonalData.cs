using Innoplatforma.Server.Domain.Enums;
using Innoplatforma.Server.Domain.Entities.Assets;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class PersonalData : Asset
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public DateTime PassportEndDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }

    public long PassportAssetFrontId { get; set; }
    public PersonalDataAssets PersonalDataAssetFrontId { get; set; }

    public long PassportAssetsBackId { get; set; }
    public PersonalDataAssets PersonalDataAssetBacktId { get; set; }

}
