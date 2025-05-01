using HW.Core.Entities;
using HW.PersistenceDTO.OrdersDataDTO;

namespace HW.Core.Stores;

public interface IOrderRepository
{
    Task<Guid> CreateAsync(Order order);

    Task<Coordinates[]> GetAllCoordinatesAsync();

    Task<Order[]> GetOrdersByCoordinates(Coordinates coordinates);
}
