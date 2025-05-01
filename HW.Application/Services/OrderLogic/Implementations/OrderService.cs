using HW.Application.Services.AuthLogic.Exceptions;
using HW.Application.Services.OrderLogic.Interfaces;
using HW.Application.Services.SharedLogic.Exceptions;
using HW.ApplicationDTOs.ClaimLogic.Interfaces;
using HW.ApplicationDTOs.OrderDTOs;
using HW.Core.Entities;
using HW.Core.Stores;
using HW.PersistenceDTO.OrdersDataDTO;

namespace HW.Application.Services.OrderLogic.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProfessionRepository _professionRepository;
    private readonly IClaimService _claimService;
    private readonly IAccountRepository _accountRepository;

    public OrderService(IOrderRepository orderRepository, IProfessionRepository professionRepository,
        IClaimService claimService, IAccountRepository accountRepository)
    {
        _orderRepository = orderRepository;
        _professionRepository = professionRepository;
        _claimService = claimService;
        _accountRepository = accountRepository;
    }

    public async Task<Guid> CreateOrderAsync(string? creatorIdClaim, CreateOrderDTO createDTO)
    {
        var creatorId = _claimService.TryParseGuidClaim(creatorIdClaim);
        var creatorAccount = await _accountRepository.GetByIdAsync(creatorId);
        var profession = createDTO.ProfessionId is not null 
            ? await _professionRepository.GetByIdAsync(createDTO.ProfessionId.Value) 
            : null;

        var order = Order.Create(
            createDTO.Description,
            createDTO.Latitude,
            createDTO.Longitude,
            createDTO.Address,
            createDTO.Images,
            profession,
            creatorId,
            createDTO.Price,
            creatorAccount
        );

        var newOrderId = await _orderRepository.CreateAsync(order);
        return newOrderId;
    }

    public async Task<Coordinates[]> GetAllOrdersCoordinates()
    {
        var coordinates = await _orderRepository.GetAllCoordinatesAsync();

        return coordinates;
    }

    public async Task<ShortOrderDTO[]> GetShortOrdersByCoordinates(Coordinates coordinates)
    {
        var orders = await _orderRepository.GetOrdersByCoordinates(coordinates);

        var ordersDTO = orders.Select(o => new ShortOrderDTO
        {
            Id = o.Id,
            ShortDescription = o.Description != null
                ? (o.Description.Length > 100 ? o.Description[..100] : o.Description)
                : null,
            Address = o.Address,
            MainImagePath = o.Images.ElementAt(0).Path
        }).ToArray();

        return ordersDTO;
    }
}