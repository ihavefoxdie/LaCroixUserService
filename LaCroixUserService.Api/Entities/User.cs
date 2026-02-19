using LaCroix.UserService.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace LaCroix.UserService.Api.Entities;

/// <summary>
/// Represents a user
/// </summary>
public class User
{
    /// <summary>
    /// User's ID.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// User's login.
    /// </summary>
    public required string Nickname { get; set; }
    /// <summary>
    /// User's email.
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// Hash of the user's password.
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// User's name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// User's surname.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// User's gender.
    /// </summary>
    public Gender Gender { get; set; }
    /// <summary>
    /// User's date of birth.
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Date of the user's creation.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Date of the last modification made to this record.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    public Status Status { get; set; }
    public UserRole Role { get; set; }
}