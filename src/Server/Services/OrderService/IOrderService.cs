using BlazorEcommerce.Shared;

namespace Server.Services.OrderService;

public interface IOrderService
{
    Task<ServiceResponse<bool>> PlaceOrder();
}