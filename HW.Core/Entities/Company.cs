using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class Company : Account
{
    public string CompanyName { get; private set; }
    public string? Description { get; private set; }
    public string? AvatarPath { get; private set; }

    private Company(
        Email email,
        PhoneNumber phoneNumber,
        string description,
        string avatarPath,
        string passworHash,
        string companyName) : base(email, phoneNumber, passworHash)
    {
        Id = Guid.NewGuid();
        Email = email;
        PhoneNumber = phoneNumber;
        Description = description;
        AvatarPath = avatarPath;
        PasswordHash = passworHash;
        CompanyName = companyName;
    }

    private Company() { }

    public static Company Create(
        Email email,
        PhoneNumber phoneNumber,
        string description,
        string avatarPath,
        string passwordHash,
        string companyName)
    {
        return new Company(
            email,
            phoneNumber,
            description,
            avatarPath,
            passwordHash,
            companyName);
    }
}