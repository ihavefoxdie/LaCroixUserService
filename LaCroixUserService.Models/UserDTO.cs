using LaCroixUserService.Contracts.Enums;

namespace LaCroixUserService.Models
{
    public record class UserDTO(int Id, string UserName, string Email, string Name, Gender Gender, DateTime? Birthday);
}
