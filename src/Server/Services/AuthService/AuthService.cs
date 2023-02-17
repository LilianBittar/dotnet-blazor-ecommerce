using System.Security.Cryptography;
using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext context;

    public AuthService(DataContext context)
    {
        this.context = context;
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        }
        else
        {
            response.Data = "token";
        }

        return response;
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<int>
            {
                Success = false,
                Message = "User already exists."
            };
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        context.Users.Add(user);
        await context.SaveChangesAsync();
        return new ServiceResponse<int> {
            Data = user.Id,
            Message = "Registration successful!"
        };
    }

    public async Task<bool> UserExists(string email)
    {
        if (await context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
        {
            return true;
        }
        return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
