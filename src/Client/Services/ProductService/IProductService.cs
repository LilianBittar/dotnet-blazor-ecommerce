using BlazorEcommerce.Shared;

namespace Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    List<Product> products { get; set; }
    string Message {get; set;}
    int CurrentPage {get; set;}
    string LastSearchText {get; set;}
    Task GetProducts(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProduct(int productId);
    Task SearchProducts(string searchText, int page);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
}
