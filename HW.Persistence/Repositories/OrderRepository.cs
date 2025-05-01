using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using HW.PersistenceDTO.OrdersDataDTO;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order.Id;
    }

    public async Task<Coordinates[]> GetAllCoordinatesAsync()
    {
        var orders = await _context.Orders
            .Select(o => new Coordinates
                {
                    Latitude = o.Latitude,
                    Longitude = o.Longitude,
                })
            .ToArrayAsync();

        return orders;
    }

    public async Task<Order[]> GetOrdersByCoordinates(Coordinates coordinates)
    {
        var orders = await _context.Orders
            .Include(o => o.Images)
            .Where(o => o.Latitude == coordinates.Latitude && o.Longitude == coordinates.Longitude)
            .ToArrayAsync();

        return orders;
    }
}
