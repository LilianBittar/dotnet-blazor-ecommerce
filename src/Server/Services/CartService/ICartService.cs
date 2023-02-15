using BlazorEcommerce.Shared;

namespace Server.Services.CartService;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductResponse>>> GetProducts(List<CartItem> cartItems);
}
