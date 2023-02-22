using BlazorEcommerce.Shared;

namespace Client.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem cartItem);
    Task<List<CartItem>> GetCartItems();
    Task<List<CartProductResponse>> GetCartProducts();
    Task RemoveProductFromCart(int productId, int producttypeId);
    Task Update(CartProductResponse product);
    Task StoreCartItems(bool emptyLocalCart);
    Task GetCartItemsCount();
}
