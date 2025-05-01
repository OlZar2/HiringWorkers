using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class Account
{
    private readonly List<Order> _ordersAsExecutor = [];

    private readonly List<Order> _ordersAsCandidate = [];

    public Guid Id { get; protected set; }

    public Email Email { get; protected set; }

    public PhoneNumber PhoneNumber { get; protected set; }

    public string PasswordHash { get; protected set; }

    public IReadOnlyCollection<Order> OrdersAsExecutor => _ordersAsExecutor;

    public IReadOnlyCollection<Order> OrdersAsCandidate => _ordersAsCandidate;

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
