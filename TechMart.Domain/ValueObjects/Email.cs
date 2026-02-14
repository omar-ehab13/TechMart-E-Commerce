using System.Text.RegularExpressions;

namespace TechMart.Domain.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        var trimmed = email.Trim();
        if (trimmed.Length > 256)
            throw new ArgumentException("Email is too long.", nameof(email));

        if (!EmailRegex.IsMatch(trimmed))
            throw new ArgumentException("Invalid email format.", nameof(email));

        return new Email(trimmed);
    }

    public static bool TryCreate(string? email, out Email? result)
    {
        result = null;
        if (string.IsNullOrWhiteSpace(email) || email.Length > 256 || !EmailRegex.IsMatch(email.Trim()))
            return false;

        result = new Email(email.Trim());
        return true;
    }

    public bool Equals(Email? other) => other is not null && string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);

    public override bool Equals(object? obj) => Equals(obj as Email);

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;
}
