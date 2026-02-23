namespace LaCroix.UserService.Domain.Users;

/// <summary>
/// Represents a user
/// </summary>
public class User
{
    public User(string nickname, Email email, string passwordHash, string? firstName, string? lastName, Gender? gender, DateTime? birthday, Status status = Status.Active, UserRole role = UserRole.User)
    {
        Id = new Guid();
        Nickname = nickname;
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Birthday = birthday;
        Status = status;
        Role = role;
    }


    /// <summary>
    /// User's ID.
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// User's login.
    /// </summary>
    public string Nickname { get; private set; }
    /// <summary>
    /// User's email.
    /// </summary>
    public Email Email { get; private set; }
    /// <summary>
    /// Hash of the user's password.
    /// </summary>
    public string PasswordHash { get; private set; }

    /// <summary>
    /// User's name.
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// User's surname.
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// User's gender.
    /// </summary>
    public Gender? Gender { get; set; }
    /// <summary>
    /// User's date of birth.
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Date of the user's creation.
    /// </summary>
    public DateTime CreatedDate { get; init; } = DateTime.Now;
    /// <summary>
    /// Date of the last modification made to this record.
    /// </summary>
    public DateTime? UpdatedDate { get; private set; }

    public Status Status { get; private set; }
    public UserRole Role { get; private set; }
}