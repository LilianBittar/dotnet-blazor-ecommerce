using BlazorEcommerce.Shared;

namespace Server.Services.OrderService;

public interface IOrderService
{
    Task<ServiceResponse<bool>> PlaceOrder();
    Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
    Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId);
}