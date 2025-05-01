using HW.ApplicationDTOs.Shared;

namespace HW.ApplicationDTOs.OrderDTOs;

public class ShortOrderDTO
{
    public Guid Id { get; set; }

    public string? MainImagePath { get; set; }

    public string? ShortDescription { get; set; }

    public required string Address { get; set; }
}
