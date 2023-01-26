using BlazorEcommerce.Shared;

namespace Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategories();
}
