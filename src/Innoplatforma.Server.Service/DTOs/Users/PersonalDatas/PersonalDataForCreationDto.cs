using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

public class PersonalDataForCreationDto
{
    public long UserId { get; set; }
    public string PassportSeria { get; set; }
    public long PassportNumber { get; set; }
    public DateTime PassportEndDate { get; set; }
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Please, select file ...")]
    [DataType(DataType.Upload)]
    public IEnumerable<IFormFile> Images { get; set; }

}
