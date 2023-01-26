using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace Client.Services.CategoryService;

public class CategoryService : ICategoryService
{

    private readonly HttpClient _http;
    public List<Category> Categories { get; set; } = new List<Category>();

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetCategories()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
        if (response != null && response.Data != null)
        Categories = response.Data;
    }
}
