﻿using Innoplatforma.Server.Domain.Entities.Assets;
using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

public class PersonalDataForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public DateTime PassportEndDate { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }
    public ICollection<PersonalDataAssets> Assets { get; set; }
}
