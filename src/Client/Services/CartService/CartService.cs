using System.Net.Http.Json;
using BlazorEcommerce.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Services.CartService;

public class CartService : ICartService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvide;
    public CartService(ILocalStorageService localStorage, HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _localStorage = localStorage;
        _http = http;
        _authStateProvide = authStateProvider;
    }
    public event Action OnChange;

    public async Task AddToCart(CartItem cartItem)
    {
        if(await IsUserAuthenticated())
        {
            Console.WriteLine("user is authenticated");
        }
        else
        {
            Console.WriteLine("user is NOT authenticated");
        }
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            cart = new List<CartItem>();
        }
        var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId);
        if (sameItem == null)
        {
            cart.Add(cartItem);
        }
        else
        {
            sameItem.Quantity += cartItem.Quantity;
        }

        await _localStorage.SetItemAsync("cart", cart);
        await GetCartItemsCount();
    }

    private async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvide.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }

    public async Task<List<CartProductResponse>> GetCartProducts()
    {
        if (await IsUserAuthenticated())
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart");
            return response.Data;
        }
        else
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cartItems == null) 
                return new List<CartProductResponse>();
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts = 
            await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();

        return cartProducts.Data;
        }
        
    }

    public async Task RemoveProductFromCart(int productId, int producttypeId)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }
        
        var cartItem = cart.Find(x => x.ProductId == productId
            && x.ProductTypeId == producttypeId);
        if (cartItem != null) 
        {
            cart.Remove(cartItem);
            await _localStorage.SetItemAsync("cart", cart);
            await GetCartItemsCount();
        }
    }

    public async Task StoreCartItems(bool emptyLocalCart = false)
    {
        var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (localCart == null)
        {
            return;
        }

        await _http.PostAsJsonAsync("api/cart", localCart);

        if (emptyLocalCart)
        {
            await _localStorage.RemoveItemAsync("cart");
        }
        
    }

    public async Task Update(CartProductResponse product)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }
        
        var cartItem = cart.Find(x => x.ProductId == product.ProductId
            && x.ProductTypeId == product.ProductTypeId);
        if (cartItem != null) 
        {
            cartItem.Quantity = product.Quantity;
            await _localStorage.SetItemAsync("cart", cart);
        }
    }

    public async Task GetCartItemsCount()
    {
        if (await IsUserAuthenticated())
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
            var count = result.Data;

            await _localStorage.SetItemAsync<int>("cartItemsCount", count);
        }
        else
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>> ("cart");
            await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
        }

        OnChange.Invoke();
    }
}
