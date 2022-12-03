using BlazorEcommerce.Shared;

namespace Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    
}
