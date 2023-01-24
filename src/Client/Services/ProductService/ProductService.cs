using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;
    public List<Product> products { get; set; }

    public ProductService(HttpClient http)
    {
        _http = http;
    }
    public async Task GetProducts()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
        if (result != null && result.Data != null)
        products = result.Data;
    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }
}

