using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class Account
{
    public Guid Id { get; protected set; }
    public Email Email { get; protected set; }
    public PhoneNumber PhoneNumber { get; protected set; }
    public string PasswordHash { get; protected set; }

    protected Account(
        Email email,
        PhoneNumber phoneNumber,
        string passwordHash
        )
    {
        Id = Guid.NewGuid();
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
    }

    protected Account() { }
}
