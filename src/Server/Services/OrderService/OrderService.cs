using System.Security.Claims;
using BlazorEcommerce.Shared;
using Server.Data;
using Server.Services.CartService;

namespace Server.Services.OrderService;
public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly ICartService _cartService;
    private readonly IHttpContextAccessor _http;

    public OrderService(DataContext context, ICartService cartService, IHttpContextAccessor http)
    {
        _context = context;
        _cartService = cartService;
        _http = http;
    }

     private int GetUserId() => int.Parse(_http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    public async Task<ServiceResponse<bool>> PlaceOrder()
    {
        var products = (await _cartService.GetDbCartProducts()).Data;
        decimal totalPrice = 0;
        products.ForEach(product => totalPrice += product.Price * product.Quantity);

        var orderItems = new List<OrderItem>();
        products.ForEach(product => orderItems.Add(new OrderItem
        {
            ProductId = product.ProductId,
            ProductTypeId = product.ProductTypeId,
            Quantity = product.Quantity,
            TotalPrice = product.Price * product.Quantity
        }));

        var order = new Order
        {
            UserId = GetUserId(),
            OrderDate = DateTime.Now,
            TotalPrice = totalPrice,
            OrderItems = orderItems
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> {Data = true};
    }
}
