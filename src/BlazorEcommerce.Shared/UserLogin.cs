using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared;

public class UserLogin
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}
