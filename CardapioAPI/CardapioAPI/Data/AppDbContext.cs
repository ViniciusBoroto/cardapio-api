using CardapioAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Item> Items { get; set; }

}
