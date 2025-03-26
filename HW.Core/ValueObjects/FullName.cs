using HW.Core.ValueObjects.Abstract;

namespace HW.Core.ValueObjects;

public class FullName : ValueObject
{
    public string FirstName { get; }
    public string SecondName { get; }
    public string? Patronymic { get; }

    private FullName(string firstName, string secondName, string? patronymic)
    {
        FirstName = firstName;
        SecondName = secondName;
        Patronymic = patronymic;
    }

    public static FullName Create(string firstName, string secondName, string? patronymic)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("Имя не может быть пустым");
        }
        if (string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("Фамилия не может быть пустой");
        }

        return new FullName(firstName, secondName, patronymic);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return FirstName;
        yield return SecondName;
        yield return Patronymic;
    }
}