using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Services.ProductService;

public class ProductService : IProductService
{

    private readonly DataContext _context;

  

    public ProductService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products.Include(p => p.Variants).ToListAsync()
        };

        return response;    
    }

    public async Task<ServiceResponse<Product>> GetProductsAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        var product = await _context.Products
        .Include(p => p.Variants)
        .ThenInclude(v => v.ProductType)
        .FirstOrDefaultAsync(p => p.Id == productId);
        if (product == null)
        {
            response.Success = false;
            response.Message ="Sorry, but there is no product.";
        }
        else
        {
            response.Data = product;
        }
        return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
            .Where(P => P.Title.ToLower().Contains(searchText.ToLower())
            || 
            P.Description.ToLower().Contains(searchText.ToLower()))
            .Include(P => P.Variants)
            .ToListAsync()
        };
        return response;
    }
}
