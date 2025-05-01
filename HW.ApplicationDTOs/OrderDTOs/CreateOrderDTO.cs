using HW.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HW.ApplicationDTOs.OrderDTOs;

public class CreateOrderDTO
{
    public string? Description { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public required string Address { get; set; }

    public required decimal Price { get; set; }

    public List<Image>? Images { get; set; }

    public Guid? ProfessionId { get; set; }
}
