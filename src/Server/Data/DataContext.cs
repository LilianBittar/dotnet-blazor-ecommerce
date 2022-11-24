using BlazorEcommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }

}
