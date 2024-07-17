using Microsoft.EntityFrameworkCore;

namespace PetshopApi.Models;

public class PetshopContext : DbContext
{
    public PetshopContext(DbContextOptions<PetshopContext> options)
        : base(options)
    {
    }

    public DbSet<PetshopItem> PetshopItems { get; set; } = null!;
}