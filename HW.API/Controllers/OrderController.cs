using HW.API.Requests;
using HW.API.Responses.Order;
using HW.Application.Services.ImageLogic.Interfaces;
using HW.Application.Services.OrderLogic.Interfaces;
using HW.ApplicationDTOs.OrderDTOs;
using HW.Core.Entities;
using HW.PersistenceDTO.OrdersDataDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HW.API.Controllers;

[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly IOrderService _orderService;

    public OrderController(IImageService imageService, IOrderService orderService)
    {
        _imageService = imageService;
        _orderService = orderService;
    }

    [HttpPost]
    [Authorize]
    public async Task<OrderIdResponse> Create([FromForm] CreateOrderRequest createOrderRequest)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var images = await _imageService.CreateImagesAsync(createOrderRequest.ImagesFiles);

        var createOrderDTO = new CreateOrderDTO()
        {
            Description = createOrderRequest.Description,
            Latitude = createOrderRequest.Latitude,
            Longitude = createOrderRequest.Longitude,
            Address = createOrderRequest.Address,
            Images = images,
            ProfessionId = createOrderRequest.ProfessionId,
            Price = createOrderRequest.Price,
        };

        var newOrderId = await _orderService.CreateOrderAsync(userId, createOrderDTO);
        return new OrderIdResponse
        {
            OrderId = newOrderId
        };
    }

    [HttpGet("map")]
    public async Task<CoordinatesListResponse> GetOrdersCoordinates()
    {
        var coordinates = await _orderService.GetAllOrdersCoordinates();

        var response = new CoordinatesListResponse
        {
            Coordinates = coordinates
        };

        return response;
    }

    [HttpGet("coordinates")]
    public async Task<ShortOrderListResponse> GetOrdersCoordinates([FromQuery] Coordinates coordinates)
    {
        var orders = await _orderService.GetShortOrdersByCoordinates(coordinates);

        var response = new ShortOrderListResponse
        {
            Orders = orders
        };

        return response;
    }
}
