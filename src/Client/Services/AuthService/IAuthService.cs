using BlazorEcommerce.Shared;

namespace Client.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
}