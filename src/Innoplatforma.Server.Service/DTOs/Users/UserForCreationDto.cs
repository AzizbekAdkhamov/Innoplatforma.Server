namespace Innoplatforma.Server.Service.DTOs.Users
{
    public class UserForCreationDto
    {
        public string Solt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public short RoleId { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
