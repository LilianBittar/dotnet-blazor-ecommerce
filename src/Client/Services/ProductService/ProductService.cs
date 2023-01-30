using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action ProductsChanged;

    public List<Product> products { get; set; }

    public ProductService(HttpClient http)
    {
        _http = http;
    }
    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }

    public async Task GetProducts(string categoryUrl = null)
    {
        var result = categoryUrl == null ?
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/category/{categoryUrl}");
        if (result != null && result.Data != null)
            products = result.Data;

        ProductsChanged.Invoke();    
    }

}

