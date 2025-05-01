using System.ComponentModel.DataAnnotations;

namespace HW.API.Requests;

public class CreateOrderRequest
{
    public string? Description { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    [Required]
    public required string Address { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
    public decimal Price { get; set; }

    public IFormFile[] ImagesFiles { get; set; } = [];

    public Guid? ProfessionId { get; set; }
}
