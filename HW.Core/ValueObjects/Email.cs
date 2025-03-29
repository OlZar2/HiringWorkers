using HW.Core.ValueObjects.Abstract;
using System.Text.RegularExpressions;

namespace HW.Core.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }
    private static readonly Regex EmailRegex = new Regex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email не может быть пустым");

        if (!EmailRegex.IsMatch(email))
            throw new ArgumentException("Неверный формат email");

        return new Email(email);
    }

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}