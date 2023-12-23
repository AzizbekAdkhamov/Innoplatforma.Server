using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

public class PersonalDataForCreationDto
{
    public long UserId { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }

    [Required(ErrorMessage = "Please provide a valid passport end date.")]
    [DataType(DataType.Date)]
    public DateTime PassportEndDate { get; set; }

    [Required(ErrorMessage = "Please provide a valid birth date.")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Please, select file ...")]
    [DataType(DataType.Upload)]
    public IFormFile PassportAssetFront { get; set; }

    [Required(ErrorMessage = "Please, select file ...")]
    [DataType(DataType.Upload)]
    public IFormFile PassportAssetsBack { get; set; }
}
