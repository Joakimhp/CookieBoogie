using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CookbookContext : DbContext
{
    public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; } = null!;
}