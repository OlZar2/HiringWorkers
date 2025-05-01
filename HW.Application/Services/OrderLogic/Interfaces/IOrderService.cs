using HW.ApplicationDTOs.OrderDTOs;
using HW.PersistenceDTO.OrdersDataDTO;

namespace HW.Application.Services.OrderLogic.Interfaces;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(string? creatorIdClaim, CreateOrderDTO createDTO);

    Task<Coordinates[]> GetAllOrdersCoordinates();

    Task<ShortOrderDTO[]> GetShortOrdersByCoordinates(Coordinates coordinates);
}
