using Innoplatforma.Server.Domain.Commons;
using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Domain.Enums;

namespace Innoplatforma.Server.Domain.Entities.Users;

public class User : Auditable<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public bool IsVerified { get; set; }
    public short RoleId { get; set; }
    public Role Role { get; set; }
    public string Salt { get; set; }

    public List<Application> Applications { get; set; }
}
