using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public event Action ProductsChanged;

    public List<Product> products { get; set; }
    public string Message { get;set; } = "Loading products...";
    public int CurrentPage {get; set;} = 1;
    public int PageCount { get; set; } = 0;
    public string LastSearchText { get; set; } = string.Empty;

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
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/category/{categoryUrl}");
        if (result != null && result.Data != null)
            products = result.Data;

        CurrentPage = 1;
        PageCount = 0;

        if (products.Count == 0)
            Message = "No products found";

        ProductsChanged.Invoke();    
    }

    public async Task SearchProducts(string searchText, int page)
    {
        LastSearchText = searchText;
        var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");
        if (result != null && result.Data != null)
        {
            products = result.Data.Products;
            CurrentPage = result.Data.CurrentPage;
            PageCount = result.Data.Pages;
        }
        
        if (products.Count == 0) Message = "No products found.";
        ProductsChanged?.Invoke();
    }

    public async Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
        return result.Data;
    }
}

