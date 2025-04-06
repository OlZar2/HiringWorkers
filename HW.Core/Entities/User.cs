using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class User : Account
{
    public FullName FullName { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? AvatarPath { get; private set; }

    private User(
        Email email,
        PhoneNumber phoneNumber,
        FullName fullName,
        string passwordHash
        ) : base(email, phoneNumber, passwordHash )
    {
        FullName = fullName;
    }

    private User() { }

    public static User Register(
        Email email,
        PhoneNumber phoneNumber,
        FullName fullName,
        string passwordHash)
    {
        if (passwordHash == null) throw new ArgumentException("Пароль не может быть пустым");

        return new User(
            email,
            phoneNumber,
            fullName,
            passwordHash);
    }

    public void UpdateFullName(string firstName, string secondName, string? patronymic)
    {
        FullName = FullName.Create(firstName, secondName, patronymic);
    }

    public void UpdateDescription(string description) => Description = description;
}
