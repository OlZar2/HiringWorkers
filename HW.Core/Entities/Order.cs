using HW.Core.Exceptions;

namespace HW.Core.Entities;

public class Order
{

    private readonly List<Image> _images = [];

    private readonly List<Account> _candidates = [];

    public Guid Id { get; private set; }

    public string? Description { get; private set; }

    public double Latitude { get; private set; }

    public double Longitude { get; private set; }

    public string Address { get; private set; }

    public decimal Price { get; private set; }

    public Guid CreatorId { get; private set; }

    public User? Creator { get; private set; }

    public Guid? ExecutorId { get; private set; }

    public Account? Executor { get; private set; }

    public Guid? ProfessionId { get; private set; }

    public Profession? Profession { get; private set; }

    public IReadOnlyCollection<Image> Images => _images;

    public IReadOnlyCollection<Account> Candidates => _candidates;

    private Order(string? description, double latitude, double longitude, string address, List<Image>? images, 
        Profession? profession, Guid creatorId, decimal price)
    {
        CreatorId = creatorId;
        Description = description;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        Price = price;
        Profession = profession;

        if (images != null)
        {
            _images.AddRange(images);
        }
    }

    private Order() { }

    public static Order Create(string? description, double latitude, double longitude, string address, List<Image>? images,
        Profession? profession, Guid creatorId, decimal price, Account creatorAccount)
    {
        if (creatorAccount is Company)
            throw new NotEnoughRightsException("Компании не могут создавать заказы");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Адрес не может быть пустым");

        if (price < 0)
            throw new ArgumentException("Стоимость не может быть меньше 0");

        return new Order(description, latitude, longitude, address, images, profession, creatorId, price);
    }
}