using System.Net.Http.Json;
using System.Security.Claims;
using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Services.OrderService;
public class OrderService : IOrderService
{
    private readonly NavigationManager _navigationManager;
    private readonly AuthenticationStateProvider _auth;
    private readonly HttpClient _http;

    public OrderService(NavigationManager navigationManager, AuthenticationStateProvider auth, HttpClient http)
    {
        _navigationManager = navigationManager;
        _auth = auth;
        _http = http;
    }

    public async Task<List<OrderOverviewResponse>> GetOrders()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
        return result.Data;
    }

    public async Task PlaceOrder()
    {
        if (await IsUserAuthenticated())
        {
            await _http.PostAsync("api/order", null);
        }
        else
        {
            _navigationManager.NavigateTo("login");
        }
    }

     private async Task<bool> IsUserAuthenticated()
    {
        return (await _auth.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}
