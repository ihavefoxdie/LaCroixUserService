using LaCroix.UserService.Contracts.Enums;

namespace LaCroix.UserService.Models
{
    public record class UserDTO(int Id, string UserName, string Email, string Name, Gender Gender, DateTime? Birthday);
}
