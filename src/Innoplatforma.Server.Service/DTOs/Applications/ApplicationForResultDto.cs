using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Service.DTOs.Applications;

public class ApplicationForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string MotivationLetter { get; set; }
    public Status Status { get; set; }
    public string FilePath { get; set; }
}
