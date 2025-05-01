using HW.Core.ValueObjects;
using System.Collections.Generic;

namespace HW.Core.Entities;

public class User : Account
{
    private readonly List<Order> _ordersAsCreator = [];

    public FullName FullName { get; private set; }

    public string? Description { get; private set; }

    public Image? AvatarImage { get; private set; }

    public IReadOnlyCollection<Order> OrdersAsCreator => _ordersAsCreator;

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
