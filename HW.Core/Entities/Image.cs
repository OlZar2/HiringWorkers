namespace HW.Core.Entities;

public class Image
{
    public Guid Id { get; private set; }
    public string Path { get; private set; }

    private Image(string path)
    {
        Path = path;
    }

    public static Image Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Путь к картинке не может быть пустым");

        return new Image(path);
    }
}