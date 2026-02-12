using LaCroixUserService.Contracts.Enums;

namespace LaCroixUserService.Models
{
    public record class UserDTO(string UserName, string Email, string Name, Gender Gender, DateTime? Birthday);
}
