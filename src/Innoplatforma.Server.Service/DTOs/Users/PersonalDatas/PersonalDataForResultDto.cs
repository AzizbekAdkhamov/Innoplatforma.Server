using Innoplatforma.Server.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

public class PersonalDataForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime PassportEndDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }
    public string PassportFrontPhotoPath { get; set; }
    public string PassportBackPhotoPath { get; set; }
}
