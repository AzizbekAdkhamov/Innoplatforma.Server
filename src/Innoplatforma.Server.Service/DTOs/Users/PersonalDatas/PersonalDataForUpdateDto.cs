using Innoplatforma.Server.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;

public class PersonalDataForUpdateDto
{
    public string PassportSeria { get; set; }
    public long? PassportNumber { get; set; }
    public DateTime? PassportEndDate { get; set; }
    public DateTime? BirthDate { get; set; }
    public Status? Status { get; set; }
    public IFormFile? PassportAssetFront { get; set; }
    public IFormFile? PassportAssetsBack { get; set; }
}
