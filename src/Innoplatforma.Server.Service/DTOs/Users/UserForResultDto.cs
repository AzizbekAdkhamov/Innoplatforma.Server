using Innoplatforma.Server.Domain.Entities.Applications;

namespace Innoplatforma.Server.Service.DTOs.Users;

public class UserForResultDto
{
    public string Solt { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public short RoleId { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public bool IsVerified { get; set; }

    public List<Application> Applications { get; set; }
}
