using HW.Core.ValueObjects;

namespace HW.Core.Entities;

public class Company : Account
{
    public string CompanyName { get; private set; }

    public string? Description { get; private set; }

    public Image? AvatarImage { get; private set; }

    private Company(
        Email email,
        PhoneNumber phoneNumber,
        string passworHash,
        string companyName) : base(email, phoneNumber, passworHash)
    {
        CompanyName = companyName;
    }

    private Company() { }

    public static Company Register(
        Email email,
        PhoneNumber phoneNumber,
        string companyName,
        string passwordHash)
    {
        if (passwordHash == null) throw new ArgumentException("Пароль не может быть пустым");
        if (companyName == null) throw new ArgumentException("Название компании не может быть пустым");

        return new Company(
            email,
            phoneNumber,
            passwordHash,
            companyName
        );
    }

    public void UpdateDescription(string description) => Description = description;
    public void UpdateCompanyName(string companyName) =>
        CompanyName = companyName ?? throw new ArgumentException("Название компании не может быть пустым");
}