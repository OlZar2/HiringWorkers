using System.Globalization;

namespace HW.Core.Entities;

public class Profession
{
    public Guid Id { get; protected set; }

    public string Name { get; protected set; }

    public string RussianName { get; protected set; }

    protected Profession() { }

    protected Profession(string name, string russianName) 
    {
        Name = name;
        RussianName = russianName;
    }

    public static Profession Create(string name, string russianName)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название профессии не может быть пустым");

        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название профессии не может быть пустым");

        return new Profession(name, russianName);
    }
}