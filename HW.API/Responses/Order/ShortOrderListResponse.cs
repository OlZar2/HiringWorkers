using HW.ApplicationDTOs.OrderDTOs;

namespace HW.API.Responses.Order;

public class ShortOrderListResponse
{
    public ShortOrderDTO[]? Orders { get; set; }
}
