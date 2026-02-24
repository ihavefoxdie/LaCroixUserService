using System;
using System.Collections.Generic;
using System.Text;

namespace LaCroix.UserService.Domain.Users;

public sealed class Email : IEquatable<Email>
{
    public string Value { get; private set; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty.", nameof(value));

        value = value.Trim();

        if (!IsValid(value))
            throw new ArgumentException("Invalid email format.", nameof(value));

        Value = value;
    }

    private Email() { }

    //TODO : Implement a more robust email validation logic
    private static bool IsValid(string value)
    {
        return value.Contains('@') && value.Contains('.');
    }

    public override string ToString()
    {
        return Value;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Email);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }

    public bool Equals(Email? other)
    {
        if (other is null)
        {
            return false;
        }

        return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator ==(Email email1, Email email2)
    {
        if (email1 is null)
        {
            return email2 is null;
        }

        return email1.Equals(email2);
    }

    public static bool operator !=(Email email1, Email email2)
    {
        if (email1 is null)
        {
            return email2 is not null;
        }

        return !email1.Equals(email2);
    }
}