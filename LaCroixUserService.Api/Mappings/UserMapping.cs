using LaCroix.UserService.Api.Entities;
using LaCroix.UserService.Models;

namespace LaCroix.UserService.Api.Mappings;

public static class UserMapping
{
    public static UserDTO UserToUserDTO(User user)
    {
        return new UserDTO
        (
            user.Id,
            user.Username,
            user.Email,
            user.Name,
            user.Gender,
            user.Birthday
        );
    }

    public static IEnumerable<UserDTO> UsersToUserDTOs(IEnumerable<User> users)
    {
        return users.Select(UserToUserDTO);
    }
}
