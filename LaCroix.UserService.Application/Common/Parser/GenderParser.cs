using LaCroix.UserService.Domain.Users;

namespace LaCroix.UserService.Application.Common.Parser;

public class GenderParser
{
    public static Gender ParseGender(string? input)
    {
        if (Enum.TryParse<Gender>(input?.Trim(), true, out Gender result)
        && Enum.IsDefined<Gender>(result))
        {
            return result;
        }

        return Gender.Unknown;
    }
}
