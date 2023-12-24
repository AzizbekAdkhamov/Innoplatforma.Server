﻿namespace Innoplatforma.Server.Service.DTOs.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long? TelegramId { get; set; }
    public bool IsVerified { get; set; }
    public long PersonalDataId { get; set; }
}
