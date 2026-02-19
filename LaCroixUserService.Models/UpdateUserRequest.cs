using LaCroix.UserService.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace LaCroix.UserService.Models
{
    public class UpdateUserRequest
    {
        [Required]
        public required Guid Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required, EmailAddress]
        public required string Email {  get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public required string Password { get; set; }

        public Gender Gender { get; set; } = Gender.Unknown;

        public DateTime? Birthday { get; set; }
    }
}
