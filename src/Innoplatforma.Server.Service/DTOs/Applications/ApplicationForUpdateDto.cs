using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Applications;

public class ApplicationForUpdateDto
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(4), MaxLength(32)]
    public string Title { get; set; }
    public string Description { get; set; }
    public string MotivationLetter { get; set; }
    public IFormFile Asset { get; set; }
}
