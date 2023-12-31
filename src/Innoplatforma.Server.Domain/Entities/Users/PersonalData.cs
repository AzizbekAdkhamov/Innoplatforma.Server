﻿using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Assets;
using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class PersonalData : Auditable<long>
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public DateTime PassportEndDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }
    public IEnumerable<PersonalDataAssets> Assets { get; set; }
}
