using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Services.ProductService;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{ 
    private readonly IProductService _productService;
    
     public ProductController(IProductService productService)
     {
        _productService = productService;
     }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
    {
        var result = await _productService.GetProductsAsync();
        return Ok(result);
    }

    [HttpGet("{productId}")]    
    public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
    {
        var result = await _productService.GetProductsAsync(productId);
        return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(string categoryUrl)
    {
        var result = await _productService.GetProductsByCategory(categoryUrl);
        return Ok(result);
    }

     [HttpGet("search/{searchText}")]
    public async Task<ActionResult<ServiceResponse<Product>>> SearchProducts(string searchText)
    {
        var result = await _productService.SearchProducts(searchText);
        return Ok(result);
    }

}
