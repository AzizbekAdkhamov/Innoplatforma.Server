using Innoplatforma.Server.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Innoplatforma.Server.Service.DTOs.Users
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public long? TelegramId { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [PhoneNumber]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StrongPassword]
        public string Password { get; set; }
    }
}
