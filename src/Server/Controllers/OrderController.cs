using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Server.Services.OrderService;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _order;

    public OrderController(IOrderService order)
    {
        _order = order;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrder()
    {
        var result = await _order.PlaceOrder();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrders()
    {
        var result = await _order.GetOrders();
        return Ok(result);
    }
}