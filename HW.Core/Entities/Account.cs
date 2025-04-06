using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class Account
{
    public Guid Id { get; protected set; }
    public Email Email { get; protected set; } = null!;
    public PhoneNumber PhoneNumber { get; protected set; } = null!;
    public string PasswordHash { get; protected set; } = null!;

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

    public void UpdateEmail(string email) => Email = Email.Create(email);
    public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = PhoneNumber.Create(phoneNumber);
}
