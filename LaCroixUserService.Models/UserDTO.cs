using LaCroix.UserService.Contracts.Enums;

namespace LaCroix.UserService.Models
{
    public record class UserDTO(Guid Id, string Nickname, string Email, string FirstName, string LastName, Gender Gender, DateTime? Birthday);
}
